using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RuleCondition
{
    // Which neighbor(s) to check
    public int[] targets;
    public RelOp op;
    public CellColor color;
    public int quantity;

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
}
