using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Original CellBehavior defined.
 * Simulates roots growing.
 */
public class SimpleCellBehavior : Cell, ICellBehavior
{
    public Color[] colors;
    public bool switchColor;
    public bool switchColor2;

    public void Init()
    {
        color = Color.white;
        SetColor(color);
    }
   
    // This is called whenever the code or values in the inspector are changed.
    // This will eventually be moved into an EditorControl script.
    void OnValidate()
    {
        if (switchColor)
        {
            switchColor = false;

            if (color == Color.black)
            {
                color = Color.white;
                SetColor(color);
            }
            else
            {
                nextColor = colors[0];
                SetColor(color);
            }
        }

        if (switchColor2)
        {
            switchColor2 = false;

            nextColor = colors[6];
        }
    }

    public void Calculate(Color color, Neighbors neighbors)
    {
        // If either top 2 neighbors are green, become brown
        if (neighbors.GetColor(0) == colors[0] || neighbors.GetColor(2) == colors[0])
        {
            // If this cell is bottom right of green cell
            // Set initial green cell to dark green
            if (neighbors.GetColor(0) == colors[0])
            {
                neighbors.SetColorOf(0, colors[4]);
            }
            nextColor = colors[1];
        }

        // If this cell is brown, become black
        if (color == colors[1])
        {
            nextColor = colors[3];

            // Randomly select either bottom corner cell
            // set its value to orange
            switch (Random.Range(1, 3))
            {
                case 1:
                    neighbors.SetColorOf(5, colors[2]);
                    break;
                case 2:
                    neighbors.SetColorOf(7, colors[2]);
                    break;
            }
        }

        // If top right|left cell is orange, become light brown
        if (neighbors.GetColor(0) == colors[2] || neighbors.GetColor(2) == colors[2])
        {
            nextColor = colors[5];
        }

        // If any bottom cells are 
        if (color == colors[5] && neighbors.GetColor(5) == colors[6])
        {
            Debug.Log("asd");
            neighbors.SetColorOf(5, colors[1]);
        }
        // If cell is light brown and bottom neighbor is pink, 
        // Set bottom to brown
        if (color == colors[5] && neighbors.GetColor(6) == colors[6])
        {
            Debug.Log("asd");
            neighbors.SetColorOf(6, colors[1]);
        }
        if (color == colors[5] && neighbors.GetColor(7) == colors[6])
        {
            Debug.Log("asd");
            neighbors.SetColorOf(7, colors[1]);
        }
    }
}
