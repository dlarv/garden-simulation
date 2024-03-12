using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/**
 * This draws buttons which can be used in the inspector and scene view.
 */
[CustomEditor(typeof(Grid), true)]
[CanEditMultipleObjects]
public class GridEditorControls : Editor
{
    Grid grid;

    void OnEnable()
    {
        grid = (Grid)target;
    }

    // Draws two buttons at the bottom of the Grid inspector panel.
    // These allow you to create a new grid and clear an existing grid.
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); 
        if(GUILayout.Button("Create Grid"))
        {
            grid.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            grid.ClearGrid();
        }
    }
}
