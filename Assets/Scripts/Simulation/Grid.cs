using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * Handles grid creation and cell access.
 * 
 * By turning off scene and domain reload, a grid can be setup inside of Edit mode and then simulated inside of 
 * Play mode.
 * Edit > Editor > Enter Play Mode Settings
 *      > Enable "Enter Play Mode Options"
 *      > Ensure both "Reload Domain" and "Reload Scene" options are disabled.
 * NOTE: Upon exiting Play mode, the grid is deleted. It could be cool to have it remember its initial state, but
 * that isn't implemented yet.
 * 
 * Sources explaining Play Mode Settings:
 * https://docs.unity3d.com/Manual/ConfigurableEnterPlayModeDetails.html
 * https://docs.unity3d.com/Manual/SceneReloading.html
 */
[ExecuteAlways]
public class Grid : MonoBehaviour
{
    Cell[,] cells = null;
    public int gridLength;
    public Cell cell;
    public Cell deadCell;

    void Start()
    {
        // If domain and scene reloading are turned off,
        // this only executes when entering Play mode (but not exiting)
        // and when grid was not instantiated during Edit mode.
        if (Application.isPlaying && cells == null) {
            GenerateGrid();
        }
    }
    // If domain and scene reloading are turned off,
    // this only executes when an object is first created in the scene tree
    // and when exiting Play mode.
    void Awake()
    {
        // Reset grid upon exiting Play mode
        ClearGrid();
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        cells = new Cell[gridLength, gridLength];

        for (int y = 0; y < gridLength; y++)
        {
            for (int x = 0; x < gridLength; x++)
            {
                Cell nextCell = Instantiate(cell, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Cell>();
                nextCell.transform.SetParent(this.transform);

                cells[x, y] = nextCell;
            }
        }


        for (int y = 0; y < gridLength; y++)
        {
            for (int x = 0; x < gridLength; x++)
            {
                cells[x, y].neighbors = GetNeighbors(x, y);
            }
        }
    }
    public void ClearGrid()
    {
        cells = null;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject c = transform.GetChild(i).gameObject;
            if (Application.isPlaying)
                Destroy(c);
            else
                DestroyImmediate(c);
        }
    }
    private Neighbors GetNeighbors(int x, int y)
    {
        Cell[] n = new Cell[8];

        // Top Left
        if (x - 1 >= 0 && y + 1 < cells.GetLength(1))
            n[0] = cells[x - 1, y + 1];
        else
            n[0] = deadCell;
        // Top
        if (y + 1 < cells.GetLength(1))
            n[1] = cells[x, y + 1];
        else
            n[1] = deadCell;
        // Top Right
        if (x + 1 < cells.GetLength(0) && y + 1 < cells.GetLength(1))
            n[2] = cells[x + 1, y + 1];
        else
            n[2] = deadCell;
        // Left
        if (x - 1 >= 0)
            n[3] = cells[x - 1, y];
        else
            n[3] = deadCell;
        // Right
        if (x + 1 < cells.GetLength(0))
            n[4] = cells[x + 1, y];
        else
            n[4] = deadCell;
        // Bottom Left
        if (x - 1 >= 0 && y - 1 >= 0)
            n[5] = cells[x - 1, y - 1];
        else
            n[5] = deadCell;
        // Bottom
        if (y - 1 >= 0)
            n[6] = cells[x, y - 1];
        else
            n[6] = deadCell;
        // Bottom Right
        if (x + 1 < cells.GetLength(0) && y - 1 >= 0)
            n[7] = cells[x + 1, y - 1];
        else
            n[7] = deadCell;
        return new Neighbors(n);
    }

    public void Step()
    {
        if (cells == null)
            return;

        Debug.Log("Step");
        CalculateNextFrame();
        Change();
    }

    void CalculateNextFrame()
    {
        foreach (Cell cell in cells)
            cell.Calculate();
    }
    void Change()
    {
        foreach (Cell cell in cells)
            cell.Change();
    }


}