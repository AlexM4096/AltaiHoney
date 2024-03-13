using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create EnterProcessingAction")]
    public class EnterProcessingAction : Action
    {
        public override void Execute(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().ProcessingTimer.Start();
    }
}