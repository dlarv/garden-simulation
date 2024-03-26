using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RuleSet))]
public class RuleSetEditor : Editor
{

    public string[] selStrings = { "GT", "GE", "LT", "LE", "EQ", "NE" };

    public RuleSet ruleset;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        ruleset = (RuleSet)target;

        for (int i = 0; i < ruleset.rules.Count; i++)
        {
            GUILayout.Label("Rule " + (i + 1), GUILayout.Height(60));

            for (int j = 0; j < ruleset.rules[i].conditions.Length; j++)
            {
                GUILayout.Label("Condition " + (j + 1), GUILayout.Height(50));

                GUILayout.BeginHorizontal("box");

                ruleset.rules[i].GetCondition(j).targetString = EditorGUILayout.TextField(ruleset.rules[i].GetCondition(j).targetString);

                ruleset.rules[i].GetCondition(j).CalculateTargets();

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                ruleset.rules[i].GetCondition(j).color.color = EditorGUILayout.ColorField("", ruleset.rules[i].GetCondition(j).GetColor(), GUILayout.Width(50));

                ruleset.rules[i].GetCondition(j).op = RuleCondition.CalculateOp(EditorGUILayout.Popup(ruleset.rules[i].GetCondition(j).GetRelOp(), selStrings));

                ruleset.rules[i].GetCondition(j).quantity = int.Parse(EditorGUILayout.TextField(ruleset.rules[i].GetCondition(j).quantity.ToString()));

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
                GUILayout.Label("Result " + (j + 1), GUILayout.Height(40));

                GUILayout.BeginHorizontal("box");

                ruleset.rules[i].result.results[j].GetCellColor(0).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(0).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(0).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(0).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(1).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(1).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(1).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(1).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(2).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(2).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(2).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(2).isNull, "", GUILayout.Width(30));

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                ruleset.rules[i].result.results[j].GetCellColor(3).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(3).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(3).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(3).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(4).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(4).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(4).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(4).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(5).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(5).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(5).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(5).isNull, "", GUILayout.Width(30));

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");

                ruleset.rules[i].result.results[j].GetCellColor(6).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(6).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(6).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(6).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(7).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(7).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(7).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(7).isNull, "", GUILayout.Width(30));

                ruleset.rules[i].result.results[j].GetCellColor(8).color = EditorGUILayout.ColorField("", ruleset.rules[i].result.results[j].GetCellColor(8).color, GUILayout.Width(50));

                ruleset.rules[i].result.results[j].GetCellColor(8).isNull = GUILayout.Toggle(ruleset.rules[i].result.results[j].GetCellColor(8).isNull, "", GUILayout.Width(30));

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