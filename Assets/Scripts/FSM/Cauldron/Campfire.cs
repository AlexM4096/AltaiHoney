using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public bool FireIsActive;
    public GameObject Fire;
    public void Start()
    {
        Fire = GameObject.Find("Fire");
        Fire.SetActive(false);
    }
    public void  ToggleFire()
    {
        FireIsActive = !FireIsActive;
        Fire.SetActive(FireIsActive);
    }
}
