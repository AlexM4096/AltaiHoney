using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Cauldron/Create SpoonProgressbar")]
public class SpoonProgressbar : Decision
{
    private Collider2D _collider;
    private ContactFilter2D _contactFilter;
    private readonly List<Collider2D> _hitCollider2Ds = new ();
    private float _speedSpoon;
    private float _valueProgressbar;
    
    public float ValueProgressbar
    {
        get => _valueProgressbar;
        set => _valueProgressbar = Mathf.Clamp(value, 0, 1000);
    }

    public override void ResetVariables()
    {
        ValueProgressbar = 0;
        _speedSpoon = 0;
    }
    public override bool Decide(StateMachine stateMachine)
    {
        _collider = stateMachine.GetComponent<LinkToCauldronCollider>().CauldronCollider;
        Physics2D.OverlapCollider(_collider, _contactFilter.NoFilter(), _hitCollider2Ds);
        foreach (var hit in _hitCollider2Ds)
            if (hit.name == "Spoon")
            {
                _speedSpoon = hit.GetComponent<Rigidbody2D>().velocity.magnitude ;
                if (_speedSpoon > 1)
                    ValueProgressbar += _speedSpoon * 0.2f;
            }
        ValueProgressbar -= 1;
        Debug.Log(ValueProgressbar);
        if (ValueProgressbar > 990)
            return true;
        return false;
    }
}
