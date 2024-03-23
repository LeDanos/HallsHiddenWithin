using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable{
    private Transform rb;
    private bool isOpen=false;
    public GameObject point;
    public void Interact(){
        rb = GetComponent<Transform>();
        if (isOpen==false)
        {
            isOpen=true;
            rb.RotateAround(point.transform.position,Vector3.up,-90);
        }else
        {
            isOpen=false;
            rb.RotateAround(point.transform.position,Vector3.up,90);
        }
    }
}