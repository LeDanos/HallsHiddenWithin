using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInteractable : MonoBehaviour, IInteractable{
    public Transform playerCameraPosition;
    public Transform interactableCameraPosition;
    public bool interacted=false;
    public BoxCollider inspector;
    private float fuckingWait=10f;

    public void Interact(){
        if (interacted==false&&fuckingWait>=10)
        {
            Debug.Log("Interacted");
            interacted=true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerCameraPosition.position=Camera.main.transform.position;
            playerCameraPosition.rotation=Camera.main.transform.rotation;
            Camera.main.transform.position=interactableCameraPosition.position;
            Camera.main.transform.rotation=interactableCameraPosition.rotation;
            inspector.enabled=false;

        }
    }
    void Update(){
        if (interacted==true)
        {
            Ray ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            ra.direction*=100;
            Debug.DrawRay(ra.origin,ra.direction,Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out RaycastHit hitInfo, 100)&&hitInfo.collider.CompareTag("Button"))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        Debug.Log("Pressed le button");     //I am slowly losing it with every passing minute
                        interactObj.Interact();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Uninteracted");
                interacted=false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Camera.main.transform.position=playerCameraPosition.position;
                Camera.main.transform.rotation=playerCameraPosition.rotation;
                inspector.enabled=true;
                fuckingWait=0;
            }
        }
        if (fuckingWait<10)
        {
            fuckingWait++;
        }
    }
}