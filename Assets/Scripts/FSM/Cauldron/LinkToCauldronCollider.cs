using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToCauldronCollider : MonoBehaviour
{
    public Collider2D CauldronCollider;

    private void Awake() => CauldronCollider = GameObject.Find("CauldronCollider").GetComponent<Collider2D>();
    
}
