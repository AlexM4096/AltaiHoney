using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Cauldron/Create WaxProgressbar")]
public class WaxProgressbar : Decision
{
    private float _timer = 0;
    private float _progressSpeed = 1;
    private float max = 10;
    public bool FireIsActive;
    
    private float Timer
    {
        get => _timer;
        set => _timer = Mathf.Clamp(value, 0, max);
    }
    public override void ResetVariables()
    {
        _timer = 0;
        _progressSpeed = 1;
    }

    public override bool Decide(StateMachine stateMachine)
    {
        FireIsActive = stateMachine.GetComponent<Campfire>().FireIsActive;
        Debug.Log(Timer);
        if (FireIsActive)
            Timer += Time.deltaTime * _progressSpeed;
        else
            Timer -= Time.deltaTime;

        return !FireIsActive && Timer > (60f / 100) * max && Timer < (80f / 100) * max;
    }
}
