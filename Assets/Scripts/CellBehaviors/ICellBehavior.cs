using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellBehavior
{
    // This acts like a constructor, running any setup needed.
    public void Init();
    // This is where the rules are implemented.
    public void Calculate(Color color, Neighbors neighbors);
}
