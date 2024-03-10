using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Create State")]
    public class State : ScriptableObject
    {
        [SerializeField] private List<Action> enterActions = new();
        [SerializeField] private List<Action> exitActions = new();
        [SerializeField] private List<Action> actions = new();
        [SerializeField] private List<Transition> transitions = new();
        
        public void Enter(StateMachine stateMachine)
        {
            foreach (var action in enterActions)
                action.Execute(stateMachine);
        }
        
        public void Exit(StateMachine stateMachine)
        {
            foreach (var action in exitActions)
                action.Execute(stateMachine);
        }
        
        public void LogicUpdate(StateMachine stateMachine)
        {
            foreach (var action in actions)
                action.Execute(stateMachine);

            foreach (var transition in transitions)
            {
                if (transition.Execute(stateMachine))
                    break;
            }
        }
        
    }
}