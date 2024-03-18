using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ColorGrid
{
    public bool[] ignore = new bool[9];

    public Color[] colors = new Color[9];

    public ColorGrid(Color[] colors, bool[] ignore)
    {
        this.colors = colors;

        this.ignore = ignore;
    }

    public Color getColor(int i)
    {
        return colors[i];
    }

    public bool getIgnore(int x)
    {
        return ignore[x];
    }
}
