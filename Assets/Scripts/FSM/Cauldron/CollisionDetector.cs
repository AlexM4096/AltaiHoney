using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;
using StateMachine = FSM.StateMachine;

[CreateAssetMenu(menuName = "FSM/Create ObjectPresence")]
public class CollisionDetector : Decision
{
    [SerializeField]private Collider2D collider;
    [SerializeField]private ContactFilter2D contactFilter;
    public List<Collider2D> hitCollider2Ds = new ();

    public override bool Decide(StateMachine stateMachine)
    {
        collider = stateMachine.GetComponent<LinkToCauldronCollider>().CauldronCollider;
        Physics2D.OverlapCollider(collider, contactFilter.NoFilter(), hitCollider2Ds);
        
        foreach (var hit in hitCollider2Ds)
            if (hit.name == "Wax")
                return true;
        return false;
    }
}
