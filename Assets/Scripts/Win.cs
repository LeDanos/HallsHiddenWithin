using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject winCamera;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Time.timeScale=0;
            playerCamera.transform.position=winCamera.transform.position;
            playerCamera.transform.rotation=winCamera.transform.rotation;
            GameObject.Find("Player").GetComponent<PlayerMenus>().win=true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").GetComponent<PlayerMovement>().isSprinting=false;
            Camera.main.fieldOfView=60f;
            GameObject.Find("Player").GetComponent<PlayerMovement>().SprintingOverlay.enabled=false;
        }
    }
}
