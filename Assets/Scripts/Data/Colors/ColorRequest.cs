using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * When a cell wants to influence the next state of its neighbor, it makes a 'request'.
 * This allows extra data to be passed along, e.g. if we want a 'weight' field.
 * 
 * TODO: Its mostly here as a template, it hasn't been integrated at all and may need to be changed to do so.
 */
public struct ColorRequest
{
    public readonly Color color;
    public readonly int weight;

    public ColorRequest(Color c, int w)
    {
        color = c;
        weight = w;
    }
    public ColorRequest(Color c)
    {
        color = c;
        weight = -1;
    }
}

