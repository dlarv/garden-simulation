using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CellColor

{
    public Color color;

    public string colorID;

    void OnValidate()
    {
        CalculateID();
    }

    public CellColor(Color color)
    {
        this.color = color;

        CalculateID();
    }

    public void CalculateID()
    {
        Color32 color32 = color;

        int first = color32.r;
        int second = color32.g;
        int third = color32.b;

        string returnString = string.Concat(first, second, third);

        colorID = returnString;
        //colorID = "asdasdasd";
    }

    public Color GetColor()
    {
        CalculateID();

        return color;
    }

    public bool CompareColors(CellColor otherColor)
    {
        CalculateID();
        otherColor.CalculateID();
        return colorID == otherColor.colorID;
    }
}
