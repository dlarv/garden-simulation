using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CellData
{
    public Color color;
    public string colorID;
    public bool isNull;
    
    /**
     * Can be used to select a specific ruleset for a cell to follow.
     * Can be referenced by rule conditions.
     * 
     * This has the format: Type0.Type1.Type2...TypeN
     * Using a wildcard '*' will match anything, 
     *  e.g. A.*.C only cares about whether the type contains Types A and C.
     *  so A.B.C and A.B1.C will both match.
     * A question to probably answer eventually is whether the order matters.
     *  e.g. will A.*.C match C.A.B. 
     * 
     * KISS
     */
    public string cellType;

    public CellData(Color color)
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

        colorID = $"{first:x2}{second:x2}{third:x2}";
    }

    public Color GetCellColor()
    {
        CalculateID();
        return color;
    }

    public bool IsNull()
    {
        return isNull;
    }

    public string GetCellType()
    {
        return cellType;
    }

    public bool CompareColors(CellData otherColor)
    {
        CalculateID();
        otherColor.CalculateID();
        return colorID == otherColor.colorID;
    }
}
