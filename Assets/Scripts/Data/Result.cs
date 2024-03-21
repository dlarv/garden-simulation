using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * The result of a cellbehavior calculation.
 * Has one or more grids to select from at random.
 * Each grid represents what each neighbor should become.
 */
[Serializable]
public class Result
{
    public CellColorGrid[] results;

    public CellColorGrid GetGrid(int grid)
    {
        return results[grid];
    }

    public CellColorGrid GetRandomGrid()
    {
        int x = UnityEngine.Random.Range(0, results.Length);
        return results[x];
    }
}
