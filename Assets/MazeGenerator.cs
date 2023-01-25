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

    MazeNode[,] Maze = new MazeNode[10, 10];
    
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
                    go.GetComponent<MazeNode>().init(x, z, 0);
                    Maze[x, z] = go.GetComponent<MazeNode>();
                }
                if (pregenMaze[x, z] == 1)
                {                   
                    var go = Instantiate(Wall);
                    go.transform.position =
                        new Vector3(x, go.transform.position.y, z);
                    go.GetComponent<MazeNode>().init(x, z, 1);
                    Maze[x, z] = go.GetComponent<MazeNode>();
                }
            }
        }

    }
    
    public void WaveAlgorithm(int StartX, int StartZ, int EndX, int EndZ)
    {
        int[,] StepsArray = new int[10, 10];
        for (int x = 0; x < 10; x++)
            for (int z = 0; z < 10; z++)
                StepsArray[x, z] = int.MinValue;

        StepsArray[StartX, StartZ] = 0;
        List<MazeNode> queue = new List<MazeNode>();
        queue.Add(Maze[StartX, StartZ]);

        List<MazeNode> nextQueue = new List<MazeNode>();
        int stepCount = 1;

        while(queue.Count > 0)
        {
            var curr = queue[0];
            queue.RemoveAt(0);

            if (curr.x == EndX && curr.z == EndZ)
                break;

            if (curr.x - 1 >= 0 && StepsArray[curr.x - 1, curr.z] == int.MinValue && pregenMaze[curr.x - 1, curr.z] == 0)
            {
                nextQueue.Add(Maze[curr.x - 1, curr.z]);
                StepsArray[curr.x - 1, curr.z] = stepCount;
            }

            if (curr.x + 1 < 10 && StepsArray[curr.x + 1, curr.z] == int.MinValue && pregenMaze[curr.x + 1, curr.z] == 0)
            {
                nextQueue.Add(Maze[curr.x - 1, curr.z]);
                StepsArray[curr.x - 1, curr.z] = stepCount;
            }

            if (curr.z - 1 >= 0 && StepsArray[curr.x, curr.z - 1] == int.MinValue && pregenMaze[curr.x, curr.z - 1] == 0)
            {
                nextQueue.Add(Maze[curr.x - 1, curr.z]);
                StepsArray[curr.x - 1, curr.z] = stepCount;
            }

            if (curr.z < 10 && StepsArray[curr.x, curr.z + 1] == int.MinValue && pregenMaze[curr.x, curr.z + 1] == 0)
            {
                nextQueue.Add(Maze[curr.x - 1, curr.z]);
                StepsArray[curr.x - 1, curr.z] = stepCount;
            }

            if (queue.Count == 0)
            {
                queue.AddRange(nextQueue);
                stepCount++;
            }

            if (StepsArray[EndX, EndZ] == int.MinValue)
            {
                Debug.Log("Impossible path");
            }
            else
            {
                /**/
            }
        }
    }
}
