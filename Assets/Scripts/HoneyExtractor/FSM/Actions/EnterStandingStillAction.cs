using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create EnterStandingStillAction")]
    public class EnterStandingStillAction : Action
    {
        public override void Execute(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().DragRotation.CanDrag = true;
    }
}