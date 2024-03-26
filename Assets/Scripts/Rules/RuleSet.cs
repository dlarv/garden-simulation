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
    public List<Rule> rules;
    public RuleSet()
    {
        rules = new List<Rule>();
    }

    public void SetRuleSet(Rule[] rules)
    {
        this.rules = new List<Rule>();
        this.rules.AddRange(rules);
    }
    public int Size()
    {
        return rules.Count;
    }

    public void AddRule()
    {
        rules.Add(new Rule(new RuleCondition(), new Result()));
    }

    public void RemoveRule(int removeInt)
    {
        rules.RemoveAt(removeInt);
    }
}
