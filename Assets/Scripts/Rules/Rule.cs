using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public RuleCondition[] conditions;

    public Result result;

    public Rule(RuleCondition[] conditions, Result result)
    {
        this.conditions = conditions;
        this.result = result;
    }

    public Rule(RuleCondition condition, Result result)
    {
        this.conditions = new RuleCondition[] { condition };
        this.result = result;
    }

    public Result Check(Neighbors neighbors)
    {
        foreach (RuleCondition cond in conditions)
        {
            if (!cond.Check(neighbors))
            {
                return null;
            }
        }
        return result;
    }
}
