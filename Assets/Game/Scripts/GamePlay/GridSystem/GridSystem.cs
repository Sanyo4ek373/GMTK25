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

        public void SetTile()
        {
            
        }
    }
}