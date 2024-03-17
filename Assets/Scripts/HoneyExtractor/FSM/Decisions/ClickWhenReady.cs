using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create ClickWhenReady")]
    public class ClickWhenReady : Decision
    {
        public override bool Decide(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().Clicky.IsClicked;
    }
}