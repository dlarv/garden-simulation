using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * This object contains the ruleset being used by dynamic cells.
 * The editor controls to change the rules should interface with this object.
 */
[Serializable]
public class RuleSet : MonoBehaviour
{
    public List<Rule> ruleSet;
    public RuleSet()
    {
        ruleSet = new List<Rule>();
    }

    public void SetRuleSet(Rule[] rules)
    {
        ruleSet = new List<Rule>();
        ruleSet.AddRange(rules);
    }

    public List<Rule> GetRuleSet()
    {
        return ruleSet;
    }

    // Convert ArrayList to regular array.
    public Rule[] AsArray()
    {
        return ruleSet.ToArray();
    }

    public void Add(Rule rule)
    {
        ruleSet.Add(rule);
    }
    public Rule Remove(int index)
    {
        Rule returnRule = ruleSet[index];

        ruleSet.RemoveAt(index);

        return returnRule;
    }
    public void Remove(Rule rule)
    {
        ruleSet.Remove(rule);
    }
    public void MoveRule(int ruleIndex, int newIndex)
    {
        // Ensure ruleIndex is in bounds.
        if (ruleIndex < 0 || ruleIndex >= Size())
            return;
        // Ensure newIndex is in bounds.
        if (newIndex < 0)
            newIndex = 0;
        else if (newIndex >= Size())
            newIndex = Size() - 1;

        Rule rule = ruleSet[ruleIndex];
        ruleSet.RemoveAt(ruleIndex);
        ruleSet.Insert(newIndex, rule);
    }
    public int Size()
    {
        return ruleSet.Count;
    }
    // Get all color states mentioned in rules.
    public Color[] ColorStatesUsedInRules()
    {
        HashSet<Color> states = new HashSet<Color>();

        foreach (Rule rule in ruleSet)
        {
            states.UnionWith(rule.GetRelatedColors());
        }
        Color[] output = new List<Color>(states).ToArray();
        return output;
    }

   
}
