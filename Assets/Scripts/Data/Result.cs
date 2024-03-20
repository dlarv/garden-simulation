using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Result
{
    public CellColorGrid[] results;

    public CellColorGrid GetGrid(int grid)
    {
        return results[grid];
    }
}
