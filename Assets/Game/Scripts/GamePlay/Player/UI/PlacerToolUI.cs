using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlacerToolUI : View
    {
        [SerializeField] private List<PlaceableUI> _placeables;
        private PlaceableUI _placeableUI;
        
        private void Awake()
        {
            foreach (var placeable in _placeables) 
                placeable.OnClick += HandleClick;
        }

        private void HandleClick(PlaceableUI placeable)
        {
            if (_placeableUI == placeable)
                return;

            if (_placeableUI != null)
                _placeableUI.SetSelected(false);
            
            _placeableUI = placeable;
            placeable.SetSelected(true);
        }
    }
}