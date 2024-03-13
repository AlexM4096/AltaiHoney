using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create ProcessFinished")]
    public class ProcessFinished : Decision
    {
        public override bool Decide(StateMachine stateMachine) =>
            !stateMachine.GetComponent<Extacrtor>().ProcessingTimer.IsRunning;
    }
}