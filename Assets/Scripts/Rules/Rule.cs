using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public RuleCondition[] conditions;

    public CellColor result;

    public Rule(RuleCondition[] conditions, CellColor result)
    {
        this.conditions = conditions;
        this.result = result;
    }

    public Rule(RuleCondition condition, CellColor result)
    {
        this.conditions = new RuleCondition[] { condition };
        this.result = result;
    }

    public Color? Check(Neighbors neighbors, CellColor currentColor)
    {
        foreach (RuleCondition cond in conditions)
        {
            if (!cond.Check(neighbors))
            {
                return null;
            }
        }
        return result.GetColor();
    }
}
