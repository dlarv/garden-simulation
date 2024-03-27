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
        if (cells != null || transform.childCount == 0)
            return;

        // Collect cells from scene, if it exists
        cells = new Cell[gridLength, gridLength];
        int i = 0;
        for (int y = 0; y < gridLength && i < transform.childCount; y++)
        {
            for (int x = 0; x < gridLength && i < transform.childCount; x++)
            {
                GameObject cell = transform.GetChild(i++).gameObject;
                cells[x, y] = cell.GetComponent<Cell>();
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

    public void GenerateGrid()
    {
        ClearGrid();

        cells = new Cell[gridLength, gridLength];

        for (int y = 0; y < gridLength; y++)
        {
            for (int x = 0; x < gridLength; x++)
            {
                Cell nextCell = Instantiate(cell, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Cell>();
                nextCell.transform.SetParent(transform);

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
        Cell[] n = new Cell[9];
        Array.Fill(n, deadCell);

        // Top Left
        if (x - 1 >= 0 && y + 1 < cells.GetLength(1))
            n[0] = cells[x - 1, y + 1];
        // Top
        if (y + 1 < cells.GetLength(1))
            n[1] = cells[x, y + 1];
        // Top Right
        if (x + 1 < cells.GetLength(0) && y + 1 < cells.GetLength(1))
            n[2] = cells[x + 1, y + 1];
        // Left
        if (x - 1 >= 0)
            n[3] = cells[x - 1, y];
        // Middle
        n[4] = cells[x, y];
        // Right
        if (x + 1 < cells.GetLength(0))
            n[5] = cells[x + 1, y];
        // Bottom Left
        if (x - 1 >= 0 && y - 1 >= 0)
            n[6] = cells[x - 1, y - 1];
        // Bottom
        if (y - 1 >= 0)
            n[7] = cells[x, y - 1];
        // Bottom Right
        if (x + 1 < cells.GetLength(0) && y - 1 >= 0)
            n[8] = cells[x + 1, y - 1];

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