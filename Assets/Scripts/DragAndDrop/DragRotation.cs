using UnityEngine;

namespace DragAndDrop
{
    public class DragRotation : MonoBehaviour, IDraggable
    {
        [SerializeField] private Transform axis;

        private Vector3 AxisPosition => axis.position;
        private Vector3 Position => transform.position;

        public void OnDragStarted()
        {
       
        }

        public void OnDrag(Vector2 worldMousePosition)
        {
            Vector3 delta = worldMousePosition - (Vector2)Position;
            
            Vector3 a = Position - AxisPosition;
            Vector3 b = a + delta;
            
            float deltaAngle = (Mathf.Atan2(b.y, b.x) - Mathf.Atan2(a.y, a.x)) * Mathf.Rad2Deg;
            transform.RotateAround(AxisPosition, Vector3.forward, deltaAngle);
        }

        public void OnDragFinished()
        {
            
        }
    }
}