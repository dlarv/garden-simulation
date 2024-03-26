using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public List<RuleCondition> conditions;

    public Result result;

    public Rule(List<RuleCondition> conditions, Result result)
    {
        this.conditions = conditions;
        this.result = result;
    }

    public Rule(RuleCondition condition, Result result)
    {
        conditions = new();
        conditions.Add(condition);

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

    public void AddCondition()
    {
        conditions.Add(new RuleCondition());
    }

    public void RemoveCondition(int removeInt)
    {
        //RuleCondition contoswitch = conditions[conditions.Length - 1];
        //conditions[removeInt] = contoswitch;
        //Array.Resize(ref conditions, conditions.Length - 1);
        conditions.RemoveAt(removeInt);
    }
}
