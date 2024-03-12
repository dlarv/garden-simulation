using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This is used to control the grid/simulation.
 * Rn, this is like the Simulation.java file from our capstone project.
 * 
 * A lot of its functionality is called inside of CellManagerEditorControl.cs. But depending on how much extra
 * funcitionality is added this might be able to fold into Grid.cs.
 */
[ExecuteInEditMode]
public class CellManager : MonoBehaviour
{
    public Grid grid;

    public void Step()
    {
        if (grid == null)
            return;
        grid.Step();
    }

}
