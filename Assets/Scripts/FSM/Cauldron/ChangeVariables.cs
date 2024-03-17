using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FSM;
using UnityEngine;
using Action = FSM.Action;

[CreateAssetMenu(menuName = "FSM/Create Change Variables")]
public class ChangeVariables : Action
{
    [SerializeField]private Decision _decision; 
    public override void Execute(StateMachine stateMachine)
    {
        _decision?.ResetVariables();
    }
}
