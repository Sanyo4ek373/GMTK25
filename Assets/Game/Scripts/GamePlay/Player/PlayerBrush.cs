using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
    public class PlayerBrush : IInitializable, IDisposable
    {
        private readonly GridSystem _gridSystem;
        private readonly PlayerControls _playerControls;
        private readonly Camera _camera;
        private readonly TilesDB _tilesDB;
        
        public PlayerBrush(GridSystem gridSystem, PlayerControls playerControls, TilesDB tilesDB)
        {
            _gridSystem = gridSystem;
            _playerControls = playerControls;
            _tilesDB = tilesDB;
            _camera = Camera.main;
        }
        
        public void Initialize()
        {
            _playerControls.Controls.Player.Click.performed += ClickHandler;
        }
        
        public void Dispose()
        {
            _playerControls.Controls.Player.Click.performed -= ClickHandler;
        }

        private void ClickHandler(InputAction.CallbackContext callbackContext)
        {
            var mousePosition = _playerControls.Controls.Player.Position.ReadValue<Vector2>();
            var mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);

            
        }
    }
}