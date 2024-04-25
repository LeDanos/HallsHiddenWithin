using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorInteractable : MonoBehaviour, IInteractable{
    private Transform rb;
    private bool isOpen=false;
    public GameObject point;
    public MeshRenderer doorLock;
    public bool hasKey=false;
    public void Interact(){
        Debug.Log(hasKey);
        if (hasKey==true)
        {
            Debug.Log("b");
            doorLock.enabled=false;
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
    public void Restart(){
        if (isOpen==true)
        {
            isOpen=false;
            rb.RotateAround(point.transform.position,Vector3.up,90);
        }
    }
}