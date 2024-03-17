using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create StartProcessingAction")]
    public class StartProcessingAction : Action
    {
        public override void Execute(StateMachine stateMachine)
        {
            stateMachine.GetComponent<Extacrtor>().DragRotation.CanDrag = false;
            stateMachine.GetComponent<Extacrtor>().InputItemChecker.UseItem();
        }
    }
}