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
    public bool check(Neighbors neighbors, Color currentColor)
    {
        int value = neighbors.CountColor(currentColor);

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
    public RelOp getOp()
    {
        return op;
    }

    override 
    public Color getColorState()
    {
        return colorState;
    }
}
