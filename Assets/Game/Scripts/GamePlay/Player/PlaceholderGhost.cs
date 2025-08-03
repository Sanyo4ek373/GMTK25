using UnityEngine;
using Zenject;

namespace Game
{
    public class PlaceholderGhost : MonoBehaviour
    {
        [SerializeField] private Color _withSpaceColor;
        [SerializeField] private Color _withOutSpaceColor;
        
        private GridSystem _gridSystem;
        private Vector3Int _gridPosition;
        private int _ghostSize = 2;
        private SpriteRenderer _spriteRenderer;
        private TilesDB _tilesDB;
        
        [Inject]
        public void Construct(GridSystem gridSystem, TilesDB tilesDB)
        {
            _tilesDB = tilesDB;
            _gridSystem = gridSystem;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public Vector3Int Position
        {
            get => _gridPosition;
            set
            {
                _gridPosition = value;
                transform.position = _gridSystem.CellToWorld(_gridPosition);
            }
        }

        public int GhostSize
        {
            get => _ghostSize;
            set
            {
                _ghostSize = value;
            }
        }

        private void Update()
        {
            var hasSpace = true;
            for (var x = 0; x < _ghostSize; ++x)
                for (var y = 0; y < _ghostSize; ++y)
                {
                    var position = _gridPosition - new Vector3Int(x, y, 0);
                    if (!_gridSystem.HasSpace(position))
                       hasSpace = false;
                }

            _spriteRenderer.color = hasSpace ? _withSpaceColor : _withOutSpaceColor;       
        }
    }
}