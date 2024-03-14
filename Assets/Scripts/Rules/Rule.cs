using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    private RuleCondition[] conditions;

    private Color result;

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

    public List<Color> getRelatedColors()
    {
        List<Color> colors = new List<Color>();
        colors.Add(result);

        foreach (RuleCondition cond in conditions)
        {
            colors.Add(cond.getColorState());
        }

        return colors;
    }

    public RuleCondition[] getConditions()
    {
        return conditions;
    }

    public Color getResult()
    {
        return result;
    }

    public Color check(Neighbors neighbors, Color currentColor)
    {
        foreach (RuleCondition cond in conditions)
        {
            if (!cond.check(neighbors, currentColor))
            {
                return currentColor;
            }
        }
        return result;
    }
}
