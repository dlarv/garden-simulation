using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(RuleSet), true)]
[InitializeOnLoad]
public class RuleSetInspector : Editor
{
    RuleSet rules;
     
    void Awake()
    {
        rules = (RuleSet)target;
        //ruleProp = serializedObject.FindProperty("rules");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        foreach(Rule rule in rules.GetRuleSet())
        {
            //EditorGUILayout.PropertyField(rule, new GUIContent("Rules"));
        }
    }

    void DrawRule()
    {

    }
}
