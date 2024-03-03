using UnityEngine;

namespace DragAndDrop
{
    public interface IDraggable
    {
        void OnDragStarted();
        void OnDrag(Vector2 worldMousePosition);
        void OnDragFinished();
    }
}