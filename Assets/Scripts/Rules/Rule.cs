using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public RuleCondition[] conditions;
    public Result result;

    // Create a generic rule
    public Rule()
    {
        this.conditions = new RuleCondition[] { new NeighborStateCondition(Color.black, RelOp.EQ, 1) };
        this.result = new Result(Color.black);
    }
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

    public List<Color> GetRelatedColors()
    {
        List<Color> colors = new List<Color>();
        colors.Add((Color)result.getResult(0).getColor(4));

        foreach (RuleCondition cond in conditions)
        {
            colors.Add(cond.GetColorState());
        }

        return colors;
    }

    public RuleCondition[] GetConditions()
    {
        return conditions;
    }

    public Result GetResult()
    {
        return result;
    }

#nullable enable

    public Result? Check(Neighbors neighbors, Color currentColor)
    {
        foreach (RuleCondition cond in conditions)
        {
            Debug.Log("uh oh");
            if (!cond.Check(neighbors, currentColor))
            {
                return null;
            }
        }

        Debug.Log("its true");
        return result;
    }
}
