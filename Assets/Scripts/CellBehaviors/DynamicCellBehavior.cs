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
    private static RuleSet ruleSet = null;

    public bool changeColor;

    public CellData changeToColor;

    public void Init()
    {
        if (ruleSet == null)
        {
            FindRuleSet();
        }
    }

    void OnValidate()
    {
        if (changeColor)
        {
            color = changeToColor;

            color.CalculateID();

            SetColor(color);

            SetNextColor(color);

            changeColor = false;
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
            //int x = Random.Range(0,results.results.Length);

            for(int i = 0; i < 9; i++)
            {
                if(!randGrid.IsNullAt(i))
                //if(results.GetGrid(x).GetCellColor(i).GetNull() == false)
                {
                    neighbors.SetColorOf(i, randGrid.GetCellColor(i));
                    //neighbors.SetColorOf(i, results.GetGrid(x).GetCellColor(i));
                }
            }
            return;
        }
    }
    private void FindRuleSet()
    {
        ruleSet = GameObject.Find("RuleSet").GetComponent<RuleSet>();
    }
}
