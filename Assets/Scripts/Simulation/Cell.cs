using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This handles functionality related to the GameObject present in the scene tree.
 * This acts as the parent class for CellBehavior scripts (CellBehaviors should inherit this and implement 
 * the ICellBehavior interface). 
 * 
 * To create new rules all that is required is creating a new CellBehavior script and a related prefab.
 */

// This attribute allows for the cell to change color/simulate in both Play and Edit mode.
[ExecuteAlways]
public class Cell : MonoBehaviour
{
    public Neighbors neighbors;
    public ICellBehavior behavior;
    public CellData currentState;
    public CellData nextState;
    public CellData initialState;

    // When a neighboring cell wants to influence this cell's color, it adds its preferred color into this queue. 
    // The ICellBehavior decides if/how to deal with these requests.
    protected Queue<ColorRequest> requests = new Queue<ColorRequest>();
    // This is a somewhat awkward workaround, b/c using renderer.material in edit mode throws a warning.
    protected Material material;

    void Awake()
    {
        // Unity wants renderer.sharedMaterial to be used in edit mode, but this will change the color of all the 
        // cells in the scene.
        Renderer rend = GetComponent<Renderer>();
        Material shared = rend.sharedMaterial;
        material = rend.material = new Material(shared);

        // Initialize cell behavior.
        behavior = GetComponent<ICellBehavior>();
        behavior.Init();
    }

    // Change the gameobject's color.
    public void UpdateState(CellData col)
    {
        if (!Application.isPlaying)
            initialState = col;

        material.SetColor("_Color", col.GetCellColor());
        currentState = col;
    }

    public void SetNextState(CellData col)
    {
        nextState = col;
    }
    // Set color back to value it was at during edit mode.
    public void ResetState()
    {
        UpdateState(initialState);
    }
    public CellData GetCurrentState()
    {
        return currentState;
    }

    // Neighboring cells can use this to make requests about what the cell's nextColor should be.
    // TODO: This is still just a proof of concept, idk how well it will work in practice.
    public void AppendColorRequest(ColorRequest request)
    {
        requests.Enqueue(request);
    }

    public void Change()
    {
        UpdateState(nextState);
    }
    // Called by Grid to calculate next color.
    // TODO: If colorRequests queue is used, it will most likely be used inside the behavior.Calculate() method.
    public void Calculate()
    {
        // This could return an array of colors, one for each neighbor and this cell.
        // However, for the moment this method assumes any changes are made 
        // inside of Calculate().
        behavior.Calculate(neighbors);
    }
}
