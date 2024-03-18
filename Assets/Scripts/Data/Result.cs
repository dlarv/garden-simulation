using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]

public class Result
{
    public ColorGrid[] resultColors;

    public Result(Color selfColor)
    {
        resultColors = new ColorGrid[1];

        resultColors[0] = new ColorGrid(new Color[]{ Color.black, Color.black, Color.black, Color.black, selfColor, Color.black, Color.black, Color.black, Color.black }, new bool[] { true, true, true, true, false, true, true, true, true });
    }

    public ColorGrid getResult(int neighborIndex)
    {
        return resultColors[neighborIndex];
    }
}
