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
    public void Init()
    {
        if(rules == null)
        {
            FindRuleSet();
        }
    }

    // This is where the rules are implemented.
    public void Calculate(Color color, Neighbors neighbors)
    {
        foreach (Rule rule in rules.GetRuleSet())
        {
            Color? c = rule.Check(neighbors, color);
            if (c != null)
            {
                SetNextColor((Color)c);
                return;
            }
        }
    }
    private void FindRuleSet()
    {
        rules = GameObject.Find("RuleSet").GetComponent<RuleSet>();
    }
}
