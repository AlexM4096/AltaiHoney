using System.Collections;
using UnityEngine;

namespace DragAndDrop
{
    public class DragRotation : MonoBehaviour, IDraggable
    {
        [SerializeField] private Transform axis;
        [SerializeField, Range(0, 1)] private float lerp;
        public float Rotations => Mathf.Abs(_angel / 360);

        private Vector3 AxisPosition => axis.position;
        private Vector3 Position => transform.position;

        private float _deltaAngle;
        private float _angel;

        private Coroutine _coroutine;
        
        public void OnDragStarted()
        {
            _angel = 0;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void OnDrag(Vector2 worldMousePosition)
        {
            Vector3 delta = worldMousePosition - (Vector2)Position;
            
            Vector3 a = Position - AxisPosition;
            Vector3 b = a + delta;
            
            _deltaAngle = Mathf.DeltaAngle(
                Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg,
                Mathf.Atan2(b.y, b.x) * Mathf.Rad2Deg);
            
            Rotate();

            _angel += _deltaAngle;
        }
        
        private void Rotate() => transform.RotateAround(AxisPosition, Vector3.forward, _deltaAngle);

        public void OnDragFinished()
        {
            _coroutine = StartCoroutine(RotationRoutine());
        }

        private IEnumerator RotationRoutine()
        {
            while (_deltaAngle >= Mathf.Epsilon)
            {
                _deltaAngle = Mathf.Lerp(_deltaAngle, 0, lerp);
                Rotate();
                yield return null;
            }
        }
    }
}