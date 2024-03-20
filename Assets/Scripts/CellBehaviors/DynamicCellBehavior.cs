using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This object will allow for dynamically changing its ruleset.
 * A RuleSet object must be instantiated in the scene and be named RuleSet.
 * If testing multiple different rulesets, one must be named RuleSet.
 */
public class DynamicCellBehavior : Cell, ICellBehavior
{
    private static RuleSet rules = null;

    public bool changeColor;

    public CellColor changeToColor;

    public void Init()
    {
        if (rules == null)
        {
            FindRuleSet();
        }
    }

    void OnValidate()
    {
        if (changeColor)
        {
            color = changeToColor;

            color.calculateID();

            SetColor(color);

            SetNextColor(color);

            changeColor = false;
        }
    }

    // This is where the rules are implemented.
    public void Calculate(CellColor color, Neighbors neighbors)
    {
        foreach (Rule rule in rules.GetRuleSet())
        {
            Color? c = rule.Check(neighbors, color);
            if (c != null)
            {
                SetNextColor(new CellColor((Color)c));
                return;
            }
        }
    }
    private void FindRuleSet()
    {
        rules = GameObject.Find("RuleSet").GetComponent<RuleSet>();
    }
}
