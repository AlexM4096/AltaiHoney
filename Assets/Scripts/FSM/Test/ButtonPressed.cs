using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Create ButtonPressed")]
    public class ButtonPressed : Decision
    {
        [SerializeField] private KeyCode keyCode;

        public override bool Decide(StateMachine stateMachine) => Input.GetKeyDown(keyCode);
    }
}