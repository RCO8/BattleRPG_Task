using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapBFS : MonoBehaviour
{
    public Tilemap tilemap; // Unity Inspector에서 연결할 타일맵
    public Vector3 start;   //출발점
    public Vector3 goal;    //도착점

    private Vector3Int startCell;
    private Vector3Int goalCell;

    private Queue<Vector3Int> queue = new Queue<Vector3Int>();
    private bool[,] visited;
    private Vector3Int[,] previous;

    private Vector3Int[] directions = {
        new Vector3Int(1, 0, 0), // Right
        new Vector3Int(-1, 0, 0), // Left
        new Vector3Int(0, 1, 0), // Up
        new Vector3Int(0, -1, 0) // Down
    };

    void Start()
    {
        startCell = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(start)); // 시작 지점
        goalCell = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(goal));   // 목표 지점

        visited = new bool[tilemap.size.x, tilemap.size.y];
        previous = new Vector3Int[tilemap.size.x, tilemap.size.y];

        BFS(startCell);
    }

    void BFS(Vector3Int start)
    {
        queue.Enqueue(start);
        visited[start.x, start.y] = true;

        while (queue.Count > 0)
        {
            Vector3Int current = queue.Dequeue();

            if (current == goalCell)
            {
                // Goal reached, reconstruct path using 'previous' array
                List<Vector3Int> path = new List<Vector3Int>();
                Vector3Int step = goalCell;
                while (step != startCell)
                {
                    path.Add(step);
                    step = previous[step.x, step.y];
                }
                path.Add(startCell);
                path.Reverse();

                // Print path (for debugging)
                foreach (var cell in path)
                {
                    Debug.Log("Path: " + cell);
                }

                return;
            }

            foreach (var dir in directions)
            {
                Vector3Int neighbor = current + dir;

                if (IsValidCell(neighbor) && !visited[neighbor.x, neighbor.y])
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor.x, neighbor.y] = true;
                    previous[neighbor.x, neighbor.y] = current;
                }
            }
        }
    }

    bool IsValidCell(Vector3Int cell)
    {
        return tilemap.HasTile(cell); // 예제에서는 타일이 있는지만 확인
        // 더 복잡한 유효성 검사가 필요할 수 있음 (장애물 등을 고려)
    }
}