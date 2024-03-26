using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Neighbors
{
    // If finegrain control is needed, this can be read directly.
    // Defines a square around centered on the target cell.
    // Read from left to right, top to bottom. 
    // Centermost square contains the current cell.
    public readonly Cell[] cells;

    public Neighbors(Cell[] cells)
    {
        this.cells = cells;
    }

    // The following two methods are workaround solutions kept here for fast prototyping.
    public CellData GetColor(int index)
    {
        return cells[index].GetColor();
    }
    public void SetColorOf(int index, CellData col)
    {
        if (cells[index] == null)
            return;
        cells[index].SetNextColor(col);
    }

    // Count number of non-null cells.
    public int Count()
    {
        int count = 0;
        foreach (Cell cell in cells)
        {
            if (cell != null)
                count++;
        }
        return count;
    }

    public int Count(Func<Cell, bool> lambda)
    {
        int count = 0;
        foreach (Cell cell in cells)
        {
            if (lambda(cell))
                count++;
        }
        return count;
    }


    // Get the number of cells that are a specific color.
    public int CountColor(CellData col)
    {
        int count = 0;
        foreach (Cell cell in cells)
        {
            if (cell != null && cell.GetColor().CompareColors(col))
                count++;
        }
        return count;
    }

    // Returns obj only containing cells w/ a specific color.
    public Neighbors FilterByColor(CellData col)
    {
        Cell[] filtered = new Cell[cells.Length];

        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] != null && cells[i].GetColor().CompareColors(col))
                filtered[i] = cells[i];
        }
        return new Neighbors(filtered);
    }

    // Returns obj only containing cells w/o a specific color.
    public Neighbors InverseFilterByColor(CellData col)
    {
        Cell[] filtered = new Cell[cells.Length];

        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] != null && !cells[i].GetColor().CompareColors(col))
                filtered[i] = cells[i];
        }
        return new Neighbors(filtered);
    }

    /** lambda recieves an index as a parameter and returns 
     * a boolean if it fits a given condition. 
     * For instance, to check for neighbors above cell in a 3x3 grid:
     * Neighbors n = new Neighbors(...);
     * Neighbors filteredN = n.FilterByIndex((index) => { return index < 3; });
     */
    public Neighbors FilterByIndex(Func<int, bool> lambda)
    {
        Cell[] filtered = new Cell[cells.Length];
        for (int i = 0; i < cells.Length; i++)
        {
            if (lambda(i))
                filtered[i] = cells[i];
            else
                filtered[i] = null;

        }
        return new Neighbors(filtered);
    }

    // Generic filter method.
    // lambda takes an Cell as an argument and checks whether it meets a given condition.
    public Neighbors Filter(Func<Cell, bool> lambda)
    {
        Cell[] filtered = new Cell[cells.Length];
        for (int i = 0; i < cells.Length; i++)
        {
            if (lambda(cells[i]))
                filtered[i] = cells[i];
            else
                filtered[i] = null;

        }
        return new Neighbors(filtered);
    }

}
