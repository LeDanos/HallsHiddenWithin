using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer keycard;
    public BoxCollider keycardC;
    public Light spotLight;
    public void Interact(){
        keycard.enabled=false;
        keycardC.enabled=false;
        spotLight.enabled=false;
        //GameObject.Find("Exit Lock").GetComponent<ExitLockInteractable>().hasKeycard=true;
        GameObject.Find("Key").GetComponent<KeyInteractable>().enabled=false;
    }
}