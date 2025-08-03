using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ToolBarUI : View
    {
        [SerializeField] private List<ToolUI> _tools;
        
        private PlacerToolUI _placerToolUI;

        [Inject]
        public void Construct(PlacerToolUI placerToolUI)
        {
            _placerToolUI = placerToolUI;
        }

        private void Awake()
        {
            foreach (var tool in _tools)
                tool.OnClick += SelectTool;
        }

        private void OnDestroy()
        {
            foreach (var tool in _tools)
                tool.OnClick -= SelectTool;
        }

        private void SelectTool(ToolUI toolUI)
        {
            if (toolUI.Tool != ToolUI.ToolType.Placer) 
                return;
            
            if (!_placerToolUI.gameObject.activeSelf)
                _placerToolUI.Show();
            else 
                _placerToolUI.Hide();
        }
    }
}