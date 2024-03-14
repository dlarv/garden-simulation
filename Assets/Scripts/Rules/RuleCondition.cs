using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleCondition
{
    public abstract bool check(Neighbors neighbors, Color currentColorState);
    public abstract RelOp getOp();
    public abstract Color getColorState();
}

