using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseInteractable : MonoBehaviour, IInteractable{
    public GameObject fusebox;
    public GameObject fuse;
    public void Interact(){
        fusebox.GetComponent<FuseboxManager>().fuses++;
        fuse.SetActive(false);
    }
}