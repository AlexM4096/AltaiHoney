using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Create ChangeColor")]
    public class ChangeColor : Action
    {
        [SerializeField] private Color color;
        
        public override void Execute(StateMachine stateMachine)
        {
            stateMachine.GetComponent<SpriteRenderer>().color = color;
        }
    }
}