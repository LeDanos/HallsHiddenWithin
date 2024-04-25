using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer key;
    public BoxCollider keyC;
    public Light spotLight;
    public GameObject point;
    public GameObject lockedDoor;
    public void Interact(){
        key.enabled=false;
        keyC.enabled=false;
        spotLight.enabled=false;
        lockedDoor.GetComponent<LockedDoorInteractable>().hasKey=true;
        GameObject.Find("Bob").GetComponent<BobController>().GoTo(point.transform);
        GameObject.Find("Gob").GetComponent<BobController>().GoTo(point.transform);
        GameObject.Find("Bob").GetComponent<BobController>().roamCooldown=0;
        GameObject.Find("Gob").GetComponent<BobController>().roamCooldown=0;
        GameObject.Find("Key").GetComponent<KeyInteractable>().enabled=false;
    }
}