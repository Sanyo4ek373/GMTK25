using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game
{
    public class PlaceableUI : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Color _normalColor;
        [SerializeField] private Color _selectedColor;
        
        private Image _image;
        
        public event Action<PlaceableUI> OnClick;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }

        public void SetSelected(bool selected)
        {
            _image.color = selected ?  _selectedColor : _normalColor;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
    }
}