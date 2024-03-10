using System.Collections;
using InputSystem;
using UnityEngine;

namespace DragAndDrop
{
    public class DragAndDrop : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        private Camera _mainCamera;

        private Vector2 _mousePosition;
        private Vector2 WorldMousePosition => _mainCamera.ScreenToWorldPoint(_mousePosition);
        
        private bool _isDragging;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            inputReader.MouseDownEvent += OnMouseDown;
            inputReader.MouseUpEvent += OnMouseUp;
            inputReader.MousePositionEvent += OnMousePosition;
        }

        private void OnDisable()
        {
            inputReader.MouseDownEvent -= OnMouseDown;
            inputReader.MouseUpEvent -= OnMouseUp;
            inputReader.MousePositionEvent -= OnMousePosition;
        }

        private void OnMouseDown()
        {
            Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.TryGetComponent(out IDraggable draggable))
            {
                _isDragging = true;
                StartCoroutine(DragRoutine(draggable));
            }
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }

        private void OnMousePosition(Vector2 value) => _mousePosition = value;

        private IEnumerator DragRoutine(IDraggable draggable)
        {
            draggable.OnDragStarted(WorldMousePosition);

            while (_isDragging)
            {
                draggable.OnDrag(WorldMousePosition);
                yield return null;
            }
            
            draggable.OnDragFinished();
        }
    }
}