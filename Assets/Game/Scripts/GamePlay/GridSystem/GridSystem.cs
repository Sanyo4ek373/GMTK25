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