using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ToolUI : MonoBehaviour, IPointerDownHandler
    {
        [Serializable]
        public enum ToolType
        {
            Placer   
        }
        
        [SerializeField] private ToolType _toolType;
        
        public event Action<ToolUI> OnClick;
        public ToolType Tool  => _toolType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick?.Invoke(this);            
        }
    }
}