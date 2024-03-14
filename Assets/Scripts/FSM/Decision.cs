using UnityEngine;

namespace FSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateMachine stateMachine);

        public virtual void ResetVariables()
        {
        }

    }
}