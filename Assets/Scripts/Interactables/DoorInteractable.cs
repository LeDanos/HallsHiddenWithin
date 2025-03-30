using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable{
    private Transform rb;
    public bool isOpen=false;
    public GameObject point;
    public bool interactedByPlayer=false;
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
    public void Restart(){
        if (isOpen==true)
        {
            isOpen=false;
            rb.RotateAround(point.transform.position,Vector3.up,90);
        }
    }
}