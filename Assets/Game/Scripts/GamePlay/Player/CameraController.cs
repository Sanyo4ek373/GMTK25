using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _panSpeed;
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _minZoom;
        [SerializeField] private float _maxZoom;

        private Vector3 _lastMousePosition;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }
        
        private void Update()
        {
            HandleMousePan();
            HandleMouseZoom();
        }

        private void HandleMousePan()
        {
            if (Mouse.current.middleButton.wasPressedThisFrame)
                _lastMousePosition = Mouse.current.position.ReadValue();

            if (!Mouse.current.middleButton.isPressed)
                return;

            var adjustedPanSpeed = _panSpeed * _camera.orthographicSize;
            var currentMousePosition = (Vector3)Mouse.current.position.ReadValue();
            var delta = currentMousePosition - _lastMousePosition;
            var move = new Vector3(-delta.x * adjustedPanSpeed, -delta.y * adjustedPanSpeed, 0);

            transform.Translate(move, Space.Self);
            _lastMousePosition = currentMousePosition;
        }

        private void HandleMouseZoom()
        {
            var scroll = Mouse.current.scroll.ReadValue().y;
            if (!(Mathf.Abs(scroll) > 0.01f))
                return;

            _camera.orthographicSize -= scroll * _zoomSpeed * Time.deltaTime;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minZoom, _maxZoom);
        }
    }
}