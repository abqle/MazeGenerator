using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeNode : MonoBehaviour
{
    public int x;
    public int z;
    public int value;

    public void init(int X, int Y, int V)
    {
        x = X;
        z = Y;
        value = V;
    }
}
