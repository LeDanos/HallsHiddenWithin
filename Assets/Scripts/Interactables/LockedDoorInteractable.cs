using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorInteractable : MonoBehaviour, IInteractable{
    private Transform rb;
    private bool isOpen=false;
    public GameObject point;
    public bool hasKey=false;
    public GameObject[] keycards;
    private int keycard;
    public void Start(){
        keycard=Random.Range(0,keycards.Length);
        for (int i = keycards.Length - 1; i >= 0 ; i--)
        {
            if (keycard==i)
            {
                keycards[i].GetComponent<KeyAInteractable>().Activate();
            }
        }
    }
    public void Interact(){
        Debug.Log(hasKey);
        if (hasKey==true)
        {
            Debug.Log("b");
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
}