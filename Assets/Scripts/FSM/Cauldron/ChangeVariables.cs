using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Create Change Variables")]
public class ChangeVariables : Action
{
    public WaxProgressbar waxProgressbar; 
    public override void Execute(StateMachine stateMachine)
    {
        waxProgressbar.ResetVariables();
    }
}
