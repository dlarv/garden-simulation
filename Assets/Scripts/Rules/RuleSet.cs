using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSet 
{
    private static List<Rule> ruleSet;

    public static void setRuleSet(Rule[] rules)
    {
        ruleSet = new List<Rule>();
        ruleSet.AddRange(rules);
    }

    public static List<Rule> getRuleSet()
    {
        return ruleSet;
    }

    // Convert ArrayList to regular array.
    public static Rule[] asArray()
    {
        return ruleSet.ToArray();
    }

    public static void add(Rule rule)
    {
        ruleSet.Add(rule);
    }
    public static Rule remove(int index)
    {
        Rule returnRule = ruleSet[index];

        ruleSet.RemoveAt(index);

        return returnRule;
    }
    public static void remove(Rule rule)
    {
        ruleSet.Remove(rule);
    }
    public static void moveRule(int ruleIndex, int newIndex)
    {
        // Ensure ruleIndex is in bounds.
        if (ruleIndex < 0 || ruleIndex >= size())
            return;
        // Ensure newIndex is in bounds.
        if (newIndex < 0)
            newIndex = 0;
        else if (newIndex >= size())
            newIndex = size() - 1;

        Rule rule = ruleSet[ruleIndex];
        ruleSet.RemoveAt(ruleIndex);
        ruleSet.Insert(newIndex, rule);
    }
    public static int size()
    {
        return ruleSet.Count;
    }
    // Get all color states mentioned in rules.
    public static Color[] colorStatesUsedInRules()
    {
        HashSet<Color> states = new HashSet<Color>();

        foreach (Rule rule in ruleSet)
        {
            states.UnionWith(rule.getRelatedColors());
        }
        Color[] output = new List<Color>(states).ToArray();
        return output;
    }
}
