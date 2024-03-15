using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborStateCondition : RuleCondition
{
    private int quantity;

    private RelOp op;

    private Color colorState;

    public NeighborStateCondition(Color colorState, RelOp op, int quantity)
    {
        this.colorState = colorState;
        this.op = op;
        this.quantity = quantity;
    }

    override
    public bool Check(Neighbors neighbors, Color currentColor)
    {
        int value = neighbors.CountColor(colorState);
        switch (op)
        {
            case RelOp.GT:
                return value > quantity;
            case RelOp.GE:
                return value >= quantity;
            case RelOp.LT:
                return value < quantity;
            case RelOp.LE:
                return value <= quantity;
            case RelOp.EQ:
                return value == quantity;
            case RelOp.NE:
            default:
                return value != quantity;
        }
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
