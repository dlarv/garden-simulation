using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RuleSetManager))]
public class RuleSetManagerEditor : Editor
{
    RuleSetManager manager;
    bool isUnFolded = true;
    string key = "";
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        manager = (RuleSetManager)target;
        manager.Generate();
        key = EditorGUILayout.TextField(key);
        if(GUILayout.Button("Add RuleSet") && key != "")
        {
            manager.AddRuleSet(key);
            key = "";
        }

        // Print list of valid cellTypes
        // Mostly for debugging
        isUnFolded = EditorGUILayout.Foldout(isUnFolded, "Cell Types:");
        if(isUnFolded)
        {
            foreach (string key in RuleSetManager.ruleSets.Keys)
                GUILayout.Label("- " + key);
        }
    }
}
