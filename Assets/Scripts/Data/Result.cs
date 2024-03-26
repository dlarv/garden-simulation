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

    public Result()
    {
        results = new CellColorGrid[1];
    }

    public CellColorGrid GetGrid(int grid)
    {
        return results[grid];
    }

    public CellColorGrid GetRandomGrid()
    {
        int x = UnityEngine.Random.Range(0, results.Length);
        return results[x];
    }

    public void AddResult()
    {
        Array.Resize(ref results, results.Length + 1);

        results[results.Length - 1] = new CellColorGrid();
    }

    public void RemoveResult(int removeInt)
    {
        CellColorGrid restoswitch = results[results.Length - 1];

        results[removeInt] = restoswitch;

        Array.Resize(ref results, results.Length - 1);
    }
}
