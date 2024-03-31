using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RuleSet))]
public class RuleSetEditor : Editor
{

    public string[] selStrings = { "GT", "GE", "LT", "LE", "EQ", "NE" };

    public RuleSet ruleset;

    public bool readyToSave;

    public void Awake()
    {

    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        ruleset = (RuleSet)target;

        GUILayout.BeginHorizontal("box");

        readyToSave = GUILayout.Toggle(readyToSave, "", GUILayout.Width(30));

        if (GUILayout.Button("Save Current Grid State") && readyToSave)
        {
            readyToSave = false;

            ruleset.SaveGrid();
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Load Saved Grid State"))
        {
            ruleset.LoadGrid();
        }

        for (int i = 0; i < ruleset.rules.Count; i++)
        {
            GUILayout.Label("Rule " + (i + 1), GUILayout.Height(60));

            for (int j = 0; j < ruleset.rules[i].conditions.Count; j++)
            {
                RuleCondition currentCondition = ruleset.rules[i].GetCondition(j);
                GUILayout.Label("----Condition " + (j + 1), GUILayout.Height(50));

                GUILayout.BeginHorizontal("box");

                currentCondition.targetString = EditorGUILayout.TextField(currentCondition.targetString);

                currentCondition.CalculateTargets();

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                currentCondition.color.color = EditorGUILayout.ColorField("", currentCondition.GetColor(), GUILayout.Width(50));

                currentCondition.op = RuleCondition.CalculateOp(EditorGUILayout.Popup(currentCondition.GetRelOp(), selStrings));

                currentCondition.quantity = int.Parse(EditorGUILayout.TextField(currentCondition.quantity.ToString()));

                GUILayout.EndHorizontal();

                if (GUILayout.Button("Remove Condition"))
                {
                    ruleset.rules[i].RemoveCondition(j);
                }
            }

            if (GUILayout.Button("Add Condition"))
            {
                ruleset.rules[i].AddCondition();
            }

            for (int j = 0; j < ruleset.rules[i].result.results.Length; j++)
            {
                CellColorGrid colorGrid = ruleset.rules[i].result.results[j];
                GUILayout.Label("----Result " + (j + 1), GUILayout.Height(40));

                GUILayout.BeginHorizontal("box");

                colorGrid.GetCellColor(0).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(0).color, GUILayout.Width(50));
                colorGrid.GetCellColor(0).isNull = GUILayout.Toggle(colorGrid.GetCellColor(0).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(1).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(1).color, GUILayout.Width(50));
                colorGrid.GetCellColor(1).isNull = GUILayout.Toggle(colorGrid.GetCellColor(1).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(2).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(2).color, GUILayout.Width(50));
                colorGrid.GetCellColor(2).isNull = GUILayout.Toggle(colorGrid.GetCellColor(2).isNull, "", GUILayout.Width(30));

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                colorGrid.GetCellColor(3).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(3).color, GUILayout.Width(50));
                colorGrid.GetCellColor(3).isNull = GUILayout.Toggle(colorGrid.GetCellColor(3).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(4).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(4).color, GUILayout.Width(50));
                colorGrid.GetCellColor(4).isNull = GUILayout.Toggle(colorGrid.GetCellColor(4).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(5).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(5).color, GUILayout.Width(50));
                colorGrid.GetCellColor(5).isNull = GUILayout.Toggle(colorGrid.GetCellColor(5).isNull, "", GUILayout.Width(30));

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                colorGrid.GetCellColor(6).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(6).color, GUILayout.Width(50));
                colorGrid.GetCellColor(6).isNull = GUILayout.Toggle(colorGrid.GetCellColor(6).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(7).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(7).color, GUILayout.Width(50));
                colorGrid.GetCellColor(7).isNull = GUILayout.Toggle(colorGrid.GetCellColor(7).isNull, "", GUILayout.Width(30));

                colorGrid.GetCellColor(8).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(8).color, GUILayout.Width(50));
                colorGrid.GetCellColor(8).isNull = GUILayout.Toggle(colorGrid.GetCellColor(8).isNull, "", GUILayout.Width(30));

                GUILayout.EndHorizontal();

                if (GUILayout.Button("Remove Result"))
                {
                    ruleset.rules[i].result.RemoveResult(j);
                }

            }

            if (GUILayout.Button("Add Result"))
            {
                ruleset.rules[i].result.AddResult();
            }

            if (GUILayout.Button("Remove Rule"))
            {
                ruleset.RemoveRule(i);
            }

        }

        GUILayout.BeginHorizontal("box");

        if (GUILayout.Button("Add Rule"))
        {
            ruleset = (RuleSet)target;

            ruleset.AddRule();
        }

        GUILayout.EndHorizontal();
    }

}