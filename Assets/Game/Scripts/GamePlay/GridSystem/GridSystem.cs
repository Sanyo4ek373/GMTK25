using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Game
{
    public class GridSystem
    {
        public const string k_GroundTileMap = "GroundTileMap";
        public const string k_DecorationTileMap = "DecorationTileMap";
        
        private Tilemap _groundTilemap;
        private Tilemap _decorationTilemap;

        public GridSystem(
            [Inject (Id = k_GroundTileMap)] Tilemap groundTilemap,
            [Inject (Id = k_DecorationTileMap)] Tilemap decorationTilemap
            )
        {
            _groundTilemap = groundTilemap;
            _decorationTilemap = decorationTilemap;
        }

        public bool IsWithinBounds(Vector3Int position)
        {
            return _groundTilemap.cellBounds.Contains(position);
        }

        public int GetCost(Vector3Int from, Vector3Int to)
        {
            var dx = Mathf.Abs(from.x - to.x);
            var dy = Mathf.Abs(from.y - to.y);
            return dx + dy == 2 ? 14 : 10;
        }
        
        public List<Vector3Int> GetNeighbours(Vector3Int position)
        {
            List<Vector3Int> neighbours = new();

            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue; 

                    var neighbour = new Vector3Int(position.x + dx, position.y + dy, 0);
                    if (IsWithinBounds(neighbour)) 
                        neighbours.Add(neighbour);
                }

            return neighbours;
        }
        
        public bool IsWalkable(Vector3Int position)
        {
            return !HasTile(position);
        }
        
        public TileBase GetTile(Vector3Int position)
        {
            return _decorationTilemap.GetTile(position);
        }
        
        public bool HasTile(Vector3Int position)
        {
            var isTile = _decorationTilemap.GetTile(position);
            return isTile != null;
        }

        public void SetTile(Vector3Int position, TileBase tile)
        {
            var isGround = _groundTilemap.GetTile(position);
            if (isGround != null)
                _decorationTilemap.SetTile(position, tile); 
        }

        public Vector3Int WorldToCell(Vector3 position)
        {
            position.z = 1;

            Vector3Int gridPosition = _groundTilemap.WorldToCell(position);
            gridPosition -= new Vector3Int(1, 1, 0);
            gridPosition.z = 0;
         
            return gridPosition;
        }
    }
}