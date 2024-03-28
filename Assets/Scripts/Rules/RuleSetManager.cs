using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We can rename this to plant manager if we want to.
public class RuleSetManager : MonoBehaviour
{
    public static Dictionary<string, RuleSet> ruleSets = null;
    public const string DEFAULT_KEY = "Default";

    // Essentially, empty must have a value assigned to it in the inspector,
    // but defaultRuleSet will use empty if no value is given.
    public RuleSet empty;
    public RuleSet defaultRuleSet;

    /** 
     * This method will handle logic concerning converting types.
     *  e.g. getting the proper object for cellType="A.*.C"
     * This likely will be the longest best match, 
     *  so if ruleSets has A, C, and A.C
     *  cellType = "A.C" will match the third option, even if all are technically valid.
     * But the exact implementation will likely depend on what we find we actually need.
     */
    public RuleSet GetRuleSetFromType(string cellType)
    {
        Generate();
        RuleSet def = ruleSets.GetValueOrDefault(DEFAULT_KEY);
        return ruleSets.GetValueOrDefault(cellType, def);
    }

    private void Awake()
    {
        Generate();
    }

    // Called from Editor script.
    // You should also be able to make one normally in the scene hierarchy.
    public void AddRuleSet(string key)
    {
        if (ruleSets == null)
            Generate();

        if (ruleSets.ContainsKey(key))
            return;

        Add(key, empty);
    }
    
    // Instantiate a new obj and add it to the dict.
    private void Add(string key, RuleSet set)
    {
        GameObject newRule = Instantiate(set.gameObject);
        newRule.transform.SetParent(transform);
        newRule.name = key;
        ruleSets.Add(key, newRule.GetComponent<RuleSet>());
    }

    public void Generate()
    {
        ruleSets = new Dictionary<string, RuleSet>();
        
    // Gets all ruleset objects from scene hierarchy
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject set = transform.GetChild(i).gameObject;
            string key = set.name;
            ruleSets.Add(key, set.GetComponent<RuleSet>());
        }

        // Ensure default ruleset exists
        if (ruleSets.ContainsKey(DEFAULT_KEY))
            return;
        // If defaultRuleSet has a value, use it. Otherwise use empty.
        RuleSet def = defaultRuleSet != null ? defaultRuleSet : empty;
        Add(DEFAULT_KEY, def);
    }
}
