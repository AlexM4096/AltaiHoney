using UnityEngine;

namespace DragAndDrop
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SimpleDragMovement : MonoBehaviour, IDraggable
    {
        [SerializeField, Range(0, 100)] private float speed = 10;

        private const float ZeroGravityScale = 0;
        
        private Rigidbody2D _rigidbody;
        private float _gravityScale;

        private Vector2 offset;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _gravityScale = _rigidbody.gravityScale;
        }

        public void OnDragStarted(Vector2 worldMousePosition)
        {
            _rigidbody.gravityScale = ZeroGravityScale;
            offset = (Vector2)transform.position - worldMousePosition;
        }

        public void OnDrag(Vector2 worldMousePosition)
        {
            Vector2 delta = worldMousePosition - (Vector2)transform.position + offset; 
            _rigidbody.velocity = delta * speed;
        }

        public void OnDragFinished()
        {
            _rigidbody.gravityScale = _gravityScale;
        }
    }
}