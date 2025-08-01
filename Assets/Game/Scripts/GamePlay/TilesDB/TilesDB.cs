using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    [CreateAssetMenu(fileName = "Tile DB", menuName = "Game/TileDB")]
    public class TilesDB : ScriptableObject
    { 
        [field: Header("Terrain")]
        [field: SerializeField] public TileBase Ground { get; private set; }
        [field: SerializeField] public TileBase Grass { get; private set; }
        
        [field: Header("Decorations")]
        [field: SerializeField] public TileBase Tree { get; private set; }
    }
}