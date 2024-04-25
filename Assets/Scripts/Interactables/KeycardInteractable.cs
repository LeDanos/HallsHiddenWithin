using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer keycard;
    public BoxCollider keycardC;
    public Light spotLight;
    public GameObject point;
    public void Interact(){
        keycard.enabled=false;
        keycardC.enabled=false;
        spotLight.enabled=false;
        GameObject.Find("Keycard Scan").GetComponent<KeycardScanInteractable>().hasKeycard=true;
        GameObject.Find("Keycard").GetComponent<KeycardInteractable>().enabled=false;
        GameObject.Find("Bob").GetComponent<BobController>().GoTo(point.transform);
        GameObject.Find("Gob").GetComponent<BobController>().GoTo(point.transform);
        GameObject.Find("Bob").GetComponent<BobController>().roamCooldown=0;
        GameObject.Find("Gob").GetComponent<BobController>().roamCooldown=0;
    }
}