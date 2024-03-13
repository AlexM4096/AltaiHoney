using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create OverProcessFinished")]
    public class OverProcessFinished : Decision
    {
        public override bool Decide(StateMachine stateMachine) =>
            !stateMachine.GetComponent<Extacrtor>().OverProcessingTimer.IsRunning;
    }
}