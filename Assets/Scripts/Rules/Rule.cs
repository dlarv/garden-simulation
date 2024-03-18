using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public RuleCondition[] conditions;
    public Color result;

    // Create a generic rule
    public Rule()
    {
        this.conditions = new RuleCondition[] { new NeighborStateCondition(Color.black, RelOp.EQ, 1) };
        this.result = Color.black;
    }
    public Rule(RuleCondition[] conditions, Color result)
    {
        this.conditions = conditions;
        this.result = result;
    }

    public Rule(RuleCondition condition, Color result)
    {
        this.conditions = new RuleCondition[] { condition };
        this.result = result;
    }

    public List<Color> GetRelatedColors()
    {
        List<Color> colors = new List<Color>();
        colors.Add(result);

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

    public Color GetResult()
    {
        return result;
    }

    public Color? Check(Neighbors neighbors, Color currentColor)
    {
        foreach (RuleCondition cond in conditions)
        {
            if (!cond.Check(neighbors, currentColor))
            {
                return null;
            }
        }
        return result;
    }
}
