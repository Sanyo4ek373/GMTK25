using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    [CreateAssetMenu(fileName = "WaterTile", menuName = "Game/Buildings/WaterTile")]
    public class WaterTile : Tile
    {
        [SerializeField] private AnimatedTile[] _animatedTiles;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            var length = _animatedTiles.Length;
            _animatedTiles[Mathf.Abs(position.x + position.y) % length]
                .GetTileData(position, tilemap, ref tileData);
        }

        public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
        {
            var length = _animatedTiles.Length;
            return _animatedTiles[(Mathf.Abs(position.x) + Mathf.Abs(position.y)) % length]
                        .GetTileAnimationData(position, tilemap, ref tileAnimationData);
        }
    }
}