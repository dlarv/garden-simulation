using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleCondition
{
    public abstract bool Check(Neighbors neighbors, Color currentColorState);
    public abstract RelOp GetOp();
    public abstract Color GetColorState();
}

