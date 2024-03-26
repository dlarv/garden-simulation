using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class RuleCondition
{
    // Which neighbor(s) to check
    public int[] targets;
    public RelOp op;
    public CellColor color;
    public int quantity;
    public string targetString;

    public RuleCondition()
    {
        targets = new int[0];

        op = RelOp.GT;

        color = new CellColor(Color.white);

        quantity = 0;

        targetString = "";
    }

    public bool Check(Neighbors neighbors)
    {
        Neighbors n = neighbors.FilterByIndex((index) => Array.IndexOf(targets, index) != -1);
        n = n.FilterByColor(color);
        int value = n.Count();
        return op switch
        {
            RelOp.GT => value > quantity,
            RelOp.GE => value >= quantity,
            RelOp.LT => value < quantity,
            RelOp.LE => value <= quantity,
            RelOp.EQ => value == quantity,
            _ => value != quantity,
        };
    }

    public int GetTarget(int target)
    {
        return targets[target];
    }

    public string GetTargets()
    {
        string returnString = "";

        foreach (int i in targets) 
        {
            returnString += i.ToString();
        }

        return returnString;
    }

    public Color GetColor()
    {
        return color.GetColor();
    }

    public int GetRelOp()
    {
        return op switch
        {
            RelOp.GT => 0,
            RelOp.GE => 1,
            RelOp.LT => 2,
            RelOp.LE => 3,
            RelOp.EQ => 4,
            _ => 5,
        };
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void CalculateTargets()
    {
        string[] targetArray = targetString.ToCharArray().Select(c => c.ToString()).ToArray();
        int[] targetInts = new int[targetArray.Length];

        for(int i = 0; i < targetArray.Length; i++)
        {
            try
            {
                targetInts[i] = int.Parse(targetArray[i]);
            }
            catch
            {

            }
        }

        targets = targetInts;
    }

    public static RelOp CalculateOp(int opInt)
    {
        return opInt switch
        {
            0 => RelOp.GT,
            1 => RelOp.GE,
            2 => RelOp.LT,
            3 => RelOp.LE,
            4 => RelOp.EQ,
            _ => RelOp.NE,
        };
    }
}

