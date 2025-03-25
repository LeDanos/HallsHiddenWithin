using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject lever;
    public AudioSource powerDown;
    public AudioSource powerUp;
    public bool work=false;
    public bool status=true;
    private GameObject[] lights;
    void Start()
    {
        lights=GameObject.FindGameObjectsWithTag("Light");
    }
    void Update()
    {
        if (work==true)
        {
            if (lever.GetComponent<Lever>().activated==true && status==false)
            {
                PowerOn();
                status=true;
            }else if (lever.GetComponent<Lever>().activated==false && status==true)
            {
                PowerOff();
                status=false;
            } 
        }
    }
    public void PowerOff(){
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        powerDown.enabled=true;
        powerUp.enabled=false;
        Debug.Log("Power Off");
    }
    public void PowerOn(){
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);
        }
        powerUp.enabled=true;
        powerDown.enabled=false;
        Debug.Log("Power On");
    }
}
