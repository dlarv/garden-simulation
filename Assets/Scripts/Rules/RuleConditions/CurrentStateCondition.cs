using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CurrentStateCondition : RuleCondition
{
    public CurrentStateCondition(Color requiredColorState)
    {
        op = RelOp.EQ;
        color = requiredColorState;
        quantity = 1;
        // only the middle
        targets = new int[] { 4 };
    }

    public CurrentStateCondition(Color requiredColorState, RelOp op)
    {
        // Technically, this value can only be EQ or NE.
        // However, the check method only checks if op == NE. Any other value defaults to EQ.
        this.op = op;
        color = requiredColorState;
    }

    
    public override bool Check(Neighbors neighbors, Color currentColor)
    {
        return Check(neighbors);
    }

}
