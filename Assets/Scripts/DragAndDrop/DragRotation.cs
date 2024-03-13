using System;
using System.Collections;
using UnityEngine;

namespace DragAndDrop
{
    public class DragRotation : MonoBehaviour, IDraggable
    {
        [SerializeField] private Transform axis;
        [SerializeField, Range(0, 1)] private float lerp;

        public bool CanDrag { get; set; } = true;
        
        public float Rotations => Mathf.Abs(_angel / 360);
        public float Direction { get; private set; }

        private Vector3 AxisPosition => axis.position;
        private Vector3 Position => transform.position;

        private Coroutine _coroutine;

        private float _angel;

        public void OnDragStarted(Vector2 worldMousePosition)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void OnDrag(Vector2 worldMousePosition)
        {
            float deltaAngle = CalculateDeltaAngel(worldMousePosition);
            Direction = Mathf.Sign(deltaAngle);
            Rotate(deltaAngle);
            _angel += deltaAngle;
        }

        public void OnDragFinished(Vector2 worldMousePosition)
        {
            _angel = 0;
            
            if (CanDrag)
                _coroutine = StartCoroutine(RotationRoutine(CalculateDeltaAngel(worldMousePosition)));
        }
        
        private float CalculateDeltaAngel(Vector2 worldMousePosition)
        {
            Vector3 delta = worldMousePosition - (Vector2)Position;
            
            Vector3 a = Position - AxisPosition;
            Vector3 b = a + delta;
            
            float deltaAngle = Mathf.DeltaAngle(
                Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg,
                Mathf.Atan2(b.y, b.x) * Mathf.Rad2Deg);

            return deltaAngle;
        }
            
        public void Rotate(float deltaAngle) => 
            transform.RotateAround(AxisPosition, Vector3.forward, deltaAngle);

        private IEnumerator RotationRoutine(float deltaAngle)
        {
            while (deltaAngle >= Mathf.Epsilon)
            {
                deltaAngle = Mathf.Lerp(deltaAngle, 0, lerp);
                Rotate(deltaAngle);
                yield return null;
            }
        }
    }
}