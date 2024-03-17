using UnityEngine;

namespace DragAndDrop
{
    public class Clicky : MonoBehaviour, IDraggable
    {
        public bool IsClicked { get; private set; }

        public void OnDragStarted(Vector2 worldMousePosition) => IsClicked = true;

        public void OnDrag(Vector2 worldMousePosition){}

        public void OnDragFinished(Vector2 worldMousePosition) => IsClicked = false;
    }
}