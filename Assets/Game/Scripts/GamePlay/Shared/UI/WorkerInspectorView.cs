using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class WorkerInspectorView : MonoBehaviour
    {
        [SerializeField] private Color _colorAvailable;
        [SerializeField] private Color _colorUnavailable;
        
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetAvailable(bool available)
        {
            _image.color = available ? _colorAvailable : _colorUnavailable;
        }
    }
}