using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create RotationRequired")]
    public class RotationRequired : Decision
    {
        [SerializeField, Range(1, 10)] private int rotationRequired = 1;

        public override bool Decide(StateMachine stateMachine) =>
            stateMachine.GetComponent<Extacrtor>().DragRotation.Rotations >= rotationRequired;
    }
}