using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PathFinder
    {
        private readonly GridSystem _gridSystem;
        
        public PathFinder(GridSystem gridSystem)
        {
            _gridSystem = gridSystem;
        }
        
        public List<Vector3Int> FindPath(Vector3Int start, Vector3Int end)
        {
            var openSet = new PriorityQueue<Vector3Int>();
            var cameFrom = new Dictionary<Vector3Int, Vector3Int>();

            var gScore = new Dictionary<Vector3Int, int>();
            var fScore = new Dictionary<Vector3Int, int>();

            openSet.Enqueue(start, 0);
            gScore[start] = 0;
            fScore[start] = Heuristic(start, end);

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();
                if (current == end)
                    return ReconstructPath(cameFrom, current);

                foreach (var neighbor in _gridSystem.GetNeighbours(current))
                {
                    if (!_gridSystem.IsWalkable(neighbor))
                        continue;

                    var tentativeGScore = gScore[current] + _gridSystem.GetCost(current, neighbor);
                    if (gScore.ContainsKey(neighbor) && tentativeGScore >= gScore[neighbor])
                        continue;
                    
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = tentativeGScore + Heuristic(neighbor, end);

                    if (!openSet.Contains(neighbor))
                        openSet.Enqueue(neighbor, fScore[neighbor]);
                }
            }

            return null; 
        }
        
        private int Heuristic(Vector3Int a, Vector3Int b)
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z);
        }

        private List<Vector3Int> ReconstructPath(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int current)
        {
            var path = new List<Vector3Int> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Add(current);
            }
            path.Reverse();
            return path;
        }
    }
}