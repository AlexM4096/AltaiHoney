using UnityEngine;

namespace DragAndDrop
{
    public interface IDraggable
    {
        void OnDragStarted(Vector2 worldMousePosition);
        void OnDrag(Vector2 worldMousePosition);
        void OnDragFinished();
    }
}