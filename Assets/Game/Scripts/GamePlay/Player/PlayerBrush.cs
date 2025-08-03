using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
    public class PlayerBrush : ITickable, IInitializable, IDisposable
    {
        private readonly Camera _camera;
        private readonly GridSystem _gridSystem;
        private readonly PlayerControls _playerControls;
        private readonly PlaceholderGhost _placeholderGhost;
        private readonly TilesDB _tilesDB;
        
        public PlayerBrush(
            GridSystem gridSystem,
            PlayerControls playerControls,
            PlaceholderGhost placeholderGhost,
            TilesDB tilesDB)
        {
            _tilesDB = tilesDB;
            _camera = Camera.main;
            _gridSystem = gridSystem;
            _playerControls = playerControls;
            _placeholderGhost = placeholderGhost;
        }

        public void Tick()
        {
            var position = _playerControls.Controls.Player.Position.ReadValue<Vector2>();
            var worldPosition = _camera.ScreenToWorldPoint(position);
            
            var cellPosition = _gridSystem.WorldToCell(worldPosition);
            
            _placeholderGhost.Position = cellPosition;
        }

        public void Initialize()
        {
            _playerControls.Controls.Player.Click.performed += HandleClick;
        }

        public void Dispose()
        {
            _playerControls.Controls.Player.Click.performed -= HandleClick;
        }

        private void HandleClick(InputAction.CallbackContext callbackContext)
        {
            var position = _playerControls.Controls.Player.Position.ReadValue<Vector2>();
            var worldPosition = _camera.ScreenToWorldPoint(position);
            
            var cellPosition = _gridSystem.WorldToCell(worldPosition);
            
            _gridSystem.AddBuildingGhost(cellPosition, _tilesDB.PlaceholderGhost);
        }
    }
}