using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;

public class KeypadInteractable : MonoBehaviour, IInteractable{
    public Transform playerCameraPosition;
    public Transform interactableCameraPosition;
    private float fuckingWait=10f;
    public AudioSource walk;
    public AudioSource run;
    LayerMask layerMask;
    public void Start()
    {
        layerMask = LayerMask.GetMask("Button");
    }
    public void Interact(){
        if (fuckingWait>=10)
        {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false)
            {
                Debug.Log("Interacted");
                fuckingWait=0;
                GameObject.Find("Player").GetComponent<PlayerMovement>().interacted=true;
                GameObject.Find("Player").GetComponent<PlayerMovement>().Stop();
                Camera.main.GetComponent<Pixelation>().BlockCount=360;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                playerCameraPosition.position=Camera.main.transform.position;
                playerCameraPosition.rotation=Camera.main.transform.rotation;
                Camera.main.transform.position=interactableCameraPosition.position;
                Camera.main.transform.rotation=interactableCameraPosition.rotation;
                run.enabled=false;
                walk.enabled=false;
            }else
            {
                Debug.Log("Uninteracted");
                fuckingWait=0;
                GameObject.Find("Player").GetComponent<PlayerMovement>().interacted=false;
                Camera.main.GetComponent<Pixelation>().BlockCount=180;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Camera.main.transform.position=playerCameraPosition.position;
                Camera.main.transform.rotation=playerCameraPosition.rotation;
            }
        }
    }
    void Update(){
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==true)
        {
            Ray ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            ra.direction*=100;
            Debug.DrawRay(ra.origin,ra.direction,Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out RaycastHit hitInfo, 100,layerMask)&&hitInfo.collider.CompareTag("Button"))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        Debug.Log("Pressed le button");     //I am slowly losing it with every passing minute
                        interactObj.Interact();
                    }
                }
            }
        }
    }
    void FixedUpdate(){
        if (fuckingWait<10)
        {
            fuckingWait++; //FUCK THIS FUCKING PIECE OF SHIT
        }
    }
}