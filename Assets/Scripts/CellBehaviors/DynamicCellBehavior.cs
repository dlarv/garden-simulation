using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This object will allow for dynamically changing its ruleset.
 * A RuleSet object must be instantiated in the scene and be named RuleSet.
 * If testing multiple different rulesets, one must be named RuleSet.
 */
public class DynamicCellBehavior : Cell, ICellBehavior
{
    public bool doChangeState;
    public CellData changeState;
    public RuleSetManager manager = null;
    public RuleSet ruleSet = null;

    public void Init()
    {
        FindRuleSet();
    }

    void OnValidate()
    {
        if (doChangeState)
        {
            currentState = changeState;

            currentState.CalculateID();

            UpdateState(currentState);

            SetNextState(currentState);

            doChangeState = false;
        }
    }

    // This is where the rules are implemented.
    public void Calculate(Neighbors neighbors)
    {
        foreach (Rule rule in ruleSet.rules)
        {
            Result results = rule.Check(neighbors);

            // Guard clause, reduces the amount of indentation.
            if (results == null)
                continue;

            CellColorGrid randGrid = results.GetRandomGrid();

            for(int i = 0; i < 9; i++)
            {
                if(!randGrid.IsNullAt(i))
                {
                    neighbors.SetColorOf(i, randGrid.GetCellColor(i));
                }
            }
            return;
        }
    }
    private void FindRuleSet()
    {
        //ruleSet = GameObject.Find("RuleSet").GetComponent<RuleSet>();
        manager = GameObject.Find("RuleSetManager").GetComponent<RuleSetManager>();
        ruleSet = manager.GetRuleSetFromType(currentState.GetCellType());
    }
}
