using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject Wall, Floor;
    int[,] pregenMaze = new int[10, 10]
    {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 0, 1, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 1, 0, 1, 1, 0, 1},
        {1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        {1, 0, 1, 0, 0, 0, 1, 1, 1, 1},
        {1, 0, 1, 0, 1, 0, 0, 0, 0, 1},
        {1, 0, 1, 0, 1, 1, 1, 1, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 0, 1}
    };
    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                if (pregenMaze[x, z] == 0)
                {
                    var go = Instantiate(Floor);
                    go.transform.position =
                        new Vector3(x, go.transform.position.y, z);
                }
                if (pregenMaze[x, z] == 1)
                {                   
                    var go = Instantiate(Wall);
                    go.transform.position =
                        new Vector3(x, go.transform.position.y, z);
                }
            }
        }

    }

    void Update()
    {
        
    }
}
