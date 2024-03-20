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
        calculateID();
    }

    public CellColor(Color color)
    {
        this.color = color;

        calculateID();
    }

    public void calculateID()
    {
        Color32 color32 = color;

        int first = color32.r;
        int second = color32.g;
        int third = color32.b;

        string returnString = string.Concat(first, second, third);

        colorID = returnString;

        //colorID = "asdasdasd";
    }

    public Color getColor()
    {
        calculateID();

        return color;
    }

    public bool compareColors(CellColor otherColor)
    {
        calculateID();
        otherColor.calculateID();

        if (colorID == otherColor.colorID)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
