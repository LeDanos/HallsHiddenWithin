using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable{
    public float x = 1;
    public void Interact(){
        Debug.Log("Interacted with the thing! "+x);
        x += 1;
    }
}