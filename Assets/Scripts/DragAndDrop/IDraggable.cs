using UnityEngine;

namespace DragAndDrop
{
    public interface IDraggable
    {
        bool CanDrag => true;
        
        void OnDragStarted(Vector2 worldMousePosition);
        void OnDrag(Vector2 worldMousePosition);
        void OnDragFinished(Vector2 worldMousePosition);
    }
}