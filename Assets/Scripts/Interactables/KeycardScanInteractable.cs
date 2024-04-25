using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeycardScanInteractable : MonoBehaviour, IInteractable{
    public bool isOpen=false;
    public bool isOpening=false;
    public float opening=0;
    public bool hasKeycard=false;
    public GameObject door;
    private Transform ogPos;
    public BoxCollider trigger;
    public AudioSource openStart;
    public AudioSource open;
    public AudioSource openEnd;
    public void Interact(){
        if (hasKeycard==true)
        {
            ogPos=door.transform;
            if (isOpening==false&&isOpen==false)
            {
                isOpening=true;
                trigger.enabled=false;
                GameObject.Find("Bob").GetComponent<BobController>().roamCooldown=GameObject.Find("Bob").GetComponent<BobController>().maxRoamCooldown;
                GameObject.Find("Gob").GetComponent<BobController>().roamCooldown=GameObject.Find("Gob").GetComponent<BobController>().maxRoamCooldown;
                openStart.enabled=true;
            }
        }
    }
public void FixedUpdate(){
    if (isOpening==true)
    {
        opening+=0.05f;
        if (opening>=200)
        {
            isOpening=false;
            isOpen=true;
        }
        door.transform.position= new Vector3(ogPos.position.x,ogPos.position.y+(opening/100000),ogPos.position.z);

        if (openStart.isPlaying==false&&open.enabled==false)
        {
            openStart.enabled=false;
            open.enabled=true;
        }

        if (open.enabled==true&&isOpen==true)
        {
            open.enabled=false;
            openEnd.enabled=true;
        }
    }
}

    public void Restart(){
        if (isOpen==true)
        {
            isOpen=false;
            isOpening=false;
            door.transform.position= new Vector3(ogPos.position.x,ogPos.position.y,ogPos.position.z);
            trigger.enabled=true;
        }
        opening=0;
        hasKeycard=false;
    }
}