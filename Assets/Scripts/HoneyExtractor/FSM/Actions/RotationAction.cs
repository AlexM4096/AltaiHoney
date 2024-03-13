using DragAndDrop;
using FSM;
using UnityEngine;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create RotationAction")]
    public class RotationAction : Action
    {
        [SerializeField] private float rotationAngel;
        
        public override void Execute(StateMachine stateMachine)
        {
            DragRotation dragRotation = stateMachine.GetComponent<Extacrtor>().DragRotation;
            float direction = dragRotation.Direction;
            dragRotation.Rotate(rotationAngel * direction);
        }
    }
}