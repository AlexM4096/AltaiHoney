using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Create Transition")]
    public class Transition : ScriptableObject
    {
        [SerializeField] private List<Decision> decisions;
        [SerializeField] private State nextState;

        public bool Execute(StateMachine stateMachine)
        {
            bool a = decisions.All(t => t.Decide(stateMachine));
            if (a) stateMachine.SwitchState(nextState);
            return a;
        }
    }
}