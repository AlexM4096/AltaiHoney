using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    [CreateAssetMenu(menuName = "Create InputReader", fileName = "InputReader")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        private GameInput _gameInput;

        public event Action MouseClickEvent = delegate { };
        public event Action<Vector2> MousePositionEvent = delegate { };

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                
                _gameInput.Gameplay.SetCallbacks(this);
            }
        }

        public void OnMouseClick(InputAction.CallbackContext context) 
            => MouseClickEvent.Invoke();

        public void OnMousePosition(InputAction.CallbackContext context)
            => MousePositionEvent.Invoke(context.ReadValue<Vector2>());
    }
}
