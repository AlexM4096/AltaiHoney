using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Cauldron/Create CounterFlowers")]
public class CounterFlowers : Decision
{
    [SerializeField]private Collider2D collider;
    [SerializeField]private ContactFilter2D contactFilter;
    public List<Collider2D> hitCollider2Ds = new ();
    [SerializeField] private int _count;

    public override void ResetVariables()
    {
        _count = 0;
    }
    public override bool Decide(StateMachine stateMachine)
    {
        collider = stateMachine.GetComponent<LinkToCauldronCollider>().CauldronCollider;
        Physics2D.OverlapCollider(collider, contactFilter.NoFilter(), hitCollider2Ds);
        
        foreach (var hit in hitCollider2Ds)
            if (hit.GetComponent<Flower>() && hit.GetComponent<Flower>().FlowerIsActive)
            {
                Destroy(hit.gameObject);
                _count++;
            }
        
        return _count >= 3;
    }
}
