using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward );
        }
    }
}
