using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    public bool on = false;
    public Light flashlight;
    public bool hasFlashlight=false;
    void Start()
    {
        on=false;
        flashlight.enabled=false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasFlashlight==true)
        {
            if (on==false)
            {
                on=true;
                flashlight.enabled=true;
            }else
            {
                on=false;
                flashlight.enabled=false;
            }
        }
    }
}
