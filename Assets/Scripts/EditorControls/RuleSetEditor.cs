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

    public override void OnInspectorGUI()
    {
        ruleset = (RuleSet)target;
        DrawSavedGrid();

        for (int i = 0; i < ruleset.rules.Count; i++)
        {
            GUILayout.Label("Rule " + (i + 1), GUILayout.Height(60));
            Rule currentRule = ruleset.rules[i];

            DrawRuleConditions(currentRule);

            if (GUILayout.Button("Add Condition"))
                currentRule.AddCondition();

            DrawResultsGrid(currentRule);

            if (GUILayout.Button("Add Result"))
                currentRule.result.AddResult();

            if (GUILayout.Button("Remove Rule"))
                ruleset.RemoveRule(i);
        }

        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Add Rule"))
        {
            ruleset = (RuleSet)target;
            ruleset.AddRule();
        }
        GUILayout.EndHorizontal();
    }

    // Helper methods for drawing GUI
    void DrawSavedGrid()
    {
        GUILayout.BeginHorizontal("box");

        readyToSave = GUILayout.Toggle(readyToSave, "", GUILayout.Width(30));

        if (GUILayout.Button("Save Current Grid State") && readyToSave)
        {
            readyToSave = false;
            ruleset.SaveGrid();
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Load Saved Grid State"))
            ruleset.LoadGrid();
    }
    void DrawRuleCondition(Rule rule, int index)
    {
        RuleCondition currentCondition = rule.GetCondition(index);
        GUILayout.Label("----Condition " + (index + 1), GUILayout.Height(50));

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
            rule.RemoveCondition(index);
    }
    void DrawRuleConditions(Rule rule)
    {
        for (int j = 0; j < rule.conditions.Count; j++)
        {
            DrawRuleCondition(rule, j);
        }
    }
    void DrawResultsRow(CellColorGrid colorGrid, int start, int count)
    {
        GUILayout.BeginHorizontal("box");
        for(int i = start; i < start + count; i++)
        {
            colorGrid.GetCellColor(i).color = EditorGUILayout.ColorField("", colorGrid.GetCellColor(i).color, GUILayout.Width(50));
            colorGrid.GetCellColor(i).isNull = GUILayout.Toggle(colorGrid.GetCellColor(i).isNull, "", GUILayout.Width(30));
        }
        GUILayout.EndHorizontal();
    }
    void DrawResultsGrid(Rule rule)
    {
        for (int j = 0; j < rule.result.results.Length; j++)
        {
            CellColorGrid colorGrid = rule.result.results[j];
            GUILayout.Label("----Result " + (j + 1), GUILayout.Height(40));
            DrawResultsRow(colorGrid, 0, 3);
            DrawResultsRow(colorGrid, 3, 3);
            DrawResultsRow(colorGrid, 6, 3);

            if (GUILayout.Button("Remove Result"))
                rule.result.RemoveResult(j);
        }
    }
}