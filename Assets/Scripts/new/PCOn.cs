using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Example.Scripts;
using UnityEngine;

public class PCOn : MonoBehaviour
{
    public GameObject lever;
    public Light pcLight;
    public GameObject desktop;
    public GameObject cam;
    public GameObject camOpen;

    void Update()
    {
        if (lever.GetComponent<Lever>().activated==true)
        {
            pcLight.enabled=true;
            desktop.SetActive(true);
            cam.SetActive(true);
            camOpen.SetActive(true);
        }else
        {
            pcLight.enabled=false;
            desktop.SetActive(false);
            cam.SetActive(false);
            camOpen.SetActive(false);
        }
    }
}
