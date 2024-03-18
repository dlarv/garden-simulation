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
    public void Calculate(Result result, Neighbors neighbors)
    {
        foreach (Rule rule in rules.GetRuleSet())
        {
#nullable enable

            Result? c = rule.Check(neighbors, color);
            if (c != null)
            {
                ColorGrid colorsToChange = c.getResult(0);

                for(int i = 0; i < 9; i++)
                {
                    if (colorsToChange.getIgnore(i) != true)
                    {
                        neighbors.SetColorOf(i, colorsToChange.getColor(i));
                    }
                }

                //SetNextColor((Color)c);
                return;
            }
        }
    }
    private void FindRuleSet()
    {
        rules = GameObject.Find("RuleSet").GetComponent<RuleSet>();
    }
}
