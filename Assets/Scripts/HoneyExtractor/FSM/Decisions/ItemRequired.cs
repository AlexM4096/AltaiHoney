using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create ItemRequired")]
    public class ItemRequired : Decision
    {
        public override bool Decide(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().InputItemChecker.HaveItem;
    }
}