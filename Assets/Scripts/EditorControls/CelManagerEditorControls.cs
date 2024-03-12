using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/**
 * This draws buttons which can be used in the inspector and scene view.
 */
[CustomEditor(typeof(CellManager), true)]
[InitializeOnLoad]
public class CellManagerEditorControls : Editor
{
    CellManager manager;
    void Awake()
    {
        // This line allows the buttons to exist even after the gameobject has been deselected.
        SceneView.duringSceneGui += OnScene;
        manager = (CellManager)FindFirstObjectByType(typeof(CellManager));
    }

    // This draws a button in the sceneview, which can be pressed to Step() the simulation forward.
    // If you do not see a button, try clicking on the CellManager gameobject in the scene tree.
    void OnSceneGUI()
    {
        if (manager == null)
            return;

        Handles.color = new Color(1f, .5f, .5f, 1);
        Vector2 screenPos = new Vector2(manager.transform.position.x + 20, manager.transform.position.y);
        Vector3 pos = HandleUtility.GUIPointToWorldRay(screenPos).origin;
        pos.x += 20f;
        if (Handles.Button(pos, Quaternion.identity, HandleUtility.GetHandleSize(pos) / 2, 4f, Handles.RectangleHandleCap))
        {
            manager.Step();
        }
        GUI.color = new Color(0, 0, 0, 1);
        pos.x -= 1f;
        Handles.Label(pos, "Step");
        Handles.EndGUI();
    }

    void OnScene(SceneView view)
    {
        OnSceneGUI();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Step"))
        {
            manager.Step();
        }
    }

}
