using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create EnterOverProcessingAction")]
    public class EnterOverProcessingAction : Action
    {
        public override void Execute(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().OverProcessingTimer.Start();
    }
}