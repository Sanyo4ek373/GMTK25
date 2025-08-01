using UnityEngine;
using Zenject;

namespace Game
{
    public class TownHallView : MonoBehaviour
    {
        private TownHallInspectorView _townHallInspectorView;

        [Inject]
        public void Construct(TownHallInspectorView townHallInspectorView)
        {
            _townHallInspectorView = townHallInspectorView;
        }
        
        public void OnMouseDown()
        {
            if (_townHallInspectorView.gameObject.activeSelf)
                _townHallInspectorView.Hide();
            else
                _townHallInspectorView.Show();
        }
    }
}