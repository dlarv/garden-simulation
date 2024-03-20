using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rule
{
    public RuleCondition[] conditions;

    public CellColor result;

    // Create a generic rule
    public Rule()
    {
        //this.conditions = new RuleCondition[] { new NeighborStateCondition(Color.black, RelOp.EQ, 1) };
        this.result = new CellColor(Color.black);
    }
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

    public List<Color> GetRelatedColors()
    {
        List<Color> colors = new List<Color>();
        colors.Add(result.GetColor());

        foreach (RuleCondition cond in conditions)
        {
            colors.Add(cond.GetColorState().GetColor());
        }

        return colors;
    }

    public RuleCondition[] GetConditions()
    {
        return conditions;
    }

    public CellColor GetResult()
    {
        return result;
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
