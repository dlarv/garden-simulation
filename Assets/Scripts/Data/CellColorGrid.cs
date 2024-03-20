using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CellColorGrid
{
    public CellColor[]  colorGrid = new CellColor[9];

    public CellColor GetCellColor(int cell)
    {
        return colorGrid[cell];
    }
}
