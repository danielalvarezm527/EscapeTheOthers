using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MazeGenerator : MonoBehaviour
{
    public NavMeshSurface surface;

    public int width = 40;
    public int height = 40;

    public GameObject wall;
    public GameObject player;

    private bool playerSpawned = false;
    private int[,] maze;

    void Start()
    {
        GenerateLevel();
        surface.BuildNavMesh();
    }

    void GenerateLevel()
    {
        maze = new int[width, height];
        GenerateMaze(0, 0);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y] == 1)
                {
                    Instantiate(wall, new Vector3(x * 2, 0, y * 2), Quaternion.identity);
                }
                else if (!playerSpawned)
                {
                    Instantiate(player, new Vector3(x * 2, 1, y * 2), Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }

    void GenerateMaze(int startX, int startY)
    {
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(new Vector2Int(startX, startY));
        maze[startX, startY] = 0;

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Pop();
            List<Vector2Int> neighbors = new List<Vector2Int>();

            foreach (var direction in directions)
            {
                int nx = current.x + direction.x * 2;
                int ny = current.y + direction.y * 2;

                if (nx >= 0 && ny >= 0 && nx < width && ny < height && maze[nx, ny] == 0)
                {
                    neighbors.Add(new Vector2Int(nx, ny));
                }
            }

            if (neighbors.Count > 0)
            {
                stack.Push(current);
                Vector2Int chosen = neighbors[Random.Range(0, neighbors.Count)];
                maze[chosen.x, chosen.y] = 1;
                maze[current.x + (chosen.x - current.x) / 2, current.y + (chosen.y - current.y) / 2] = 1;
                stack.Push(chosen);
            }
        }
    }
}
