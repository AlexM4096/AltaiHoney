using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    [SerializeField] private GameObject PointToRotate;
    [SerializeField] private GameObject Target;
    private bool InTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == Target.name)
            InTarget = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!InTarget)
            return;
        
        Vector2 direction = PointToRotate.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == Target.name)
            InTarget = false;
    }
}
