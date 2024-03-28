using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetInteractable : MonoBehaviour, IInteractable{
    public Transform playerCameraPosition;
    public Transform interactableCameraPosition;
    public BoxCollider inspector;
    private float fuckingWait=5f;
    public bool hiding=false;
    public AudioSource walk;
    public AudioSource run;

    public void Interact(){
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false&&fuckingWait>=5)
        {
            Debug.Log("Interacted");
            GameObject.Find("Player").GetComponent<PlayerMovement>().interacted=true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().hidden=true;
            playerCameraPosition.position=Camera.main.transform.position;
            playerCameraPosition.rotation=Camera.main.transform.rotation;
            Camera.main.transform.position=interactableCameraPosition.position;
            Camera.main.transform.rotation=interactableCameraPosition.rotation;
            inspector.enabled=false;
            fuckingWait=0;
            hiding=true;
            run.enabled=false;
            walk.enabled=false;

        }
    }
    void Update(){
        if (hiding==true&&fuckingWait>=5)
        {
            Camera.main.transform.position=interactableCameraPosition.position;
            Camera.main.transform.rotation=interactableCameraPosition.rotation;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Uninteracted");
                GameObject.Find("Player").GetComponent<PlayerMovement>().interacted=false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().hidden=false;
                Camera.main.transform.position=playerCameraPosition.position;
                Camera.main.transform.rotation=playerCameraPosition.rotation;
                inspector.enabled=true;
                fuckingWait=0;
                hiding=false;
            }
        }
        if (fuckingWait<5)
        {
            fuckingWait++;
        }
    }
}