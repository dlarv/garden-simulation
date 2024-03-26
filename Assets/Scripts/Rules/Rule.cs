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

    public RuleCondition GetCondition(int condition)
    {
        return conditions[condition];
    }

    //this is why I should just use a list...

    public void AddCondition()
    {
        Array.Resize(ref conditions, conditions.Length + 1);

        conditions[conditions.Length - 1] = new RuleCondition();
    }

    public void RemoveCondition(int removeInt)
    {
        RuleCondition contoswitch = conditions[conditions.Length - 1];

        conditions[removeInt] = contoswitch;

        Array.Resize(ref conditions, conditions.Length - 1);
    }
}
