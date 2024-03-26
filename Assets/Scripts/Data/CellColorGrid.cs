using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * Represents which colors the 3x3 grid of neighbors should become.
 * If CellColor is null, then that neighbor is ignored.
 */
[Serializable]
public class CellColorGrid
{
    public CellColor[]  colorGrid = new CellColor[9];

    public CellColorGrid()
    {
        colorGrid = new CellColor[9];
    }

    public CellColor GetCellColor(int cell)
    {
        return colorGrid[cell];
    }

    public bool IsNullAt(int cell)
    {
        return colorGrid[cell].isNull;
    }
}
