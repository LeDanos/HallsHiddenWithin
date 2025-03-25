using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyAInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer key;
    public BoxCollider keyC;
    public Light spotLight;
    public GameObject lockedDoor;
    public void Interact(){
        key.enabled=false;
        keyC.enabled=false;
        spotLight.enabled=false;
        lockedDoor.GetComponent<LockedDoorInteractable>().hasKey=true;
    }
    public void Activate(){
        key.enabled=true;
        keyC.enabled=true;
        spotLight.enabled=true;
    }
}