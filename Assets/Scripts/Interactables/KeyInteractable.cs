using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer key;
    public BoxCollider keyC;
    public Light spotLight;
    public GameObject point;
    public void Interact(){
        key.enabled=false;
        keyC.enabled=false;
        spotLight.enabled=false;
        GameObject.Find("Locked Door").GetComponent<LockedDoorInteractable>().hasKey=true;
        GameObject.Find("Key").GetComponent<KeyInteractable>().enabled=false;
        GameObject.Find("Bob").GetComponent<BobController>().GoTo(point);
        GameObject.Find("Gob").GetComponent<BobController>().GoTo(point);
    }
}