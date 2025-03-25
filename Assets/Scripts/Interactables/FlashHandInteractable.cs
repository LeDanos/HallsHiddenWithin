using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHandInteractable : MonoBehaviour, IInteractable{
    public GameObject flashHand;
    public void Start()
    {
        flashHand.SetActive(false);
    }
    public void Interact(){
        GameObject.Find("Player").GetComponent<Flashlight>().hasFlashlight=true;
        GameObject.Find("Player").GetComponent<Flashlight>().on=true;
        GameObject.Find("Player").GetComponent<Flashlight>().flashlight.enabled=true;
        flashHand.SetActive(false);
    }
}