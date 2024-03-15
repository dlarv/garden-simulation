using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStateCondition : RuleCondition
{
    private RelOp op;

    private Color colorState;

    public CurrentStateCondition(Color requiredColorState)
    {
        this.colorState = requiredColorState;
        this.op = RelOp.EQ;
    }

    public CurrentStateCondition(Color requiredColorState, RelOp op)
    {
        // Technically, this value can only be EQ or NE.
        // However, the check method only checks if op == NE. Any other value defaults to EQ.
        this.op = op;
        this.colorState = requiredColorState;
    }

    override
    public bool Check(Neighbors neighbors, Color currentColor)
    {
        if (op == RelOp.NE)
            return this.colorState != currentColor;
        return this.colorState == currentColor;
    }

    override
    public RelOp GetOp()
    {
        return op;
    }

    override
    public Color GetColorState()
    {
        return colorState;
    }
}
