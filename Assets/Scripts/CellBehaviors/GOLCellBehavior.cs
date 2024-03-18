using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class implements the normal conway game of life rules.
 * Its main purpose was to ensure the import of the ruleset system from java
 * to here was successful.
 */
public class GOLCellBehavior : Cell, ICellBehavior
{
    public GameObject rulesetPrefab;
    public static RuleSet rules;
    public bool isAlive = false;
    // This acts like a constructor, running any setup needed.
    public void Init()
    {
        if(rules == null)
        {
            GameObject obj = GameObject.Find("ConwaysRules");
            if (obj != null)
                rules = obj.GetComponent<RuleSet>();
            else 
                GenerateGOLRuleset(rulesetPrefab);
        }
    }
    void OnValidate()
    {
        if (material == null)
            return;
        if (isAlive)
            color = Color.black;
        else
            color = Color.white;
        SetColor(color);
    }
    // This is where the rules are implemented.
    public void Calculate(Result result, Neighbors neighbors)
    {
        //Debug.Log("calculated");
        foreach (Rule rule in rules.GetRuleSet())
        {
            //Debug.Log("rule tried");
#nullable enable

            Result? c = rule.Check(neighbors, color);
            if (c != null)
            {
                Debug.Log("sbf");
                ColorGrid colorsToChange = c.getResult(0);

                for (int i = 0; i < 9; i++)
                {
                    if (colorsToChange.getIgnore(i) != true)
                    {
                        Debug.Log("lec");
                        neighbors.SetColorOf(i, colorsToChange.getColor(i));
                    }
                }

                //SetNextColor((Color)c);
                return;
            }
        }
    }

    public static void GenerateGOLRuleset(GameObject obj)
    {
        rules = Instantiate(obj).GetComponent<RuleSet>();
        rules.name = "ConwaysRules";
        Color LIVE = Color.black;
        Color DEAD = Color.white;

        // Rule 1: Any live cell with fewer than two live neighbors dies (referred to as underpopulation). 
        // A dead cell with < 2 neighbors remains dead.
        rules.Add(new Rule(new NeighborStateCondition(LIVE, RelOp.LT, 2), new Result(DEAD)));

        // Rule 2: Any live cell with three or more neighbors dies (referred to as overpopulation). 
        // A dead cell with > 3 neighbors remains dead.
        rules.Add(new Rule(new NeighborStateCondition(LIVE, RelOp.GT, 3), new Result(DEAD)));

        // Rule 3: Any live cell with two OR three live neighbor's lives, unchanged, to the next generation. 
        // Rule 3 has to be broken into two parts, because this is the easiest way to emulate an OR operation.
        // Rule 3a: Any live cell with two live neighbor's lives, unchanged, to the next generation. 
        rules.Add(new Rule(
                new RuleCondition[] {
                    new CurrentStateCondition(LIVE),
                    new NeighborStateCondition(LIVE, RelOp.EQ, 2)
                }, new Result(LIVE)));

        // However, the second half of rule 3 can be combined with rule 4.
        // Rule 3b: Any live cell with three neighbors stays alive.  
        // Rule 4: Any dead cell with exactly three neighbors comes to life.  
        rules.Add(new Rule(new NeighborStateCondition(LIVE, RelOp.EQ, 3), new Result(LIVE)));
    }
}
