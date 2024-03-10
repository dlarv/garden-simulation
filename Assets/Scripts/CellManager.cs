using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public bool step;

    public Cell[,] cells;

    public int gridLength;

    public GameObject cell;

    public Cell deadCell;



    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[gridLength, gridLength];

        for (int y = 0; y < gridLength; y++)
        {
            for (int x = 0; x < gridLength; x++)
            {
                Cell nextCell = Instantiate(cell, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Cell>();
                cells[x, y] = nextCell;
            }
        }

        for (int y = 0; y < gridLength; y++)
        {
            for (int x = 0; x < gridLength; x++)
            {
                cells[x, y].SetNeighbors(GetNeighbors(x, y));
            }
        }
    }

    private Neighbors GetNeighbors(int x, int y)
    {
       Cell[] n = new Cell[8];
        // Top Left
        if(x - 1 >= 0 && y + 1 < cells.GetLength(1))
            n[0] = cells[x - 1, y + 1];
        else
            n[0] = deadCell;
        // Top
        if(y + 1 < cells.GetLength(1))
            n[1] = cells[x, y + 1];
        else
            n[1] = deadCell;
        // Top Right
        if(x + 1 < cells.GetLength(0) && y + 1 < cells.GetLength(1))
            n[2] = cells[x + 1, y + 1];
        else
            n[2] = deadCell;
        // Left
        if(x - 1 >= 0)
            n[3] = cells[x - 1, y];
        else
            n[3] = deadCell;
        // Right
        if(x + 1 < cells.GetLength(0))
            n[4] = cells[x + 1, y];
        else
            n[4] = deadCell;
        // Bottom Left
        if(x - 1 >= 0 && y - 1 >= 0)
            n[5] = cells[x - 1, y - 1];
        else
            n[5] = deadCell;
        // Bottom
        if(y - 1 >= 0)
            n[6] = cells[x, y - 1];
        else
            n[6] = deadCell;
        // Bottom Right
        if(x + 1 < cells.GetLength(0) && y - 1 >= 0)
            n[7] = cells[x + 1, y - 1];
        else
            n[7] = deadCell;
        return new Neighbors(n);
    }

    // Update is called once per frame
    void Update()
    {
        if (step)
        {
            step = false;

            foreach(Cell x in cells)
            {
                x.calculate();
            }

            foreach (Cell x in cells)
            {
                x.change();
            }
        }
    }
}
