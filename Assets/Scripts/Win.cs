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
            GameObject.Find("Player").GetComponent<PlayerMovement>().win=true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Bob").GetComponent<BobController>().run.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().walk.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().bIdle.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().bChase.enabled=false;
            GameObject.Find("Gob").GetComponent<BobController>().bIdle.enabled=false;
            GameObject.Find("Gob").GetComponent<BobController>().bChase.enabled=false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().isSprinting=false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().MainCamera.fieldOfView=60f;
            GameObject.Find("Player").GetComponent<PlayerMovement>().SprintingOverlay.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().open.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().openStart.enabled=false;
            GameObject.Find("Bob").GetComponent<BobController>().openEnd.enabled=false;
        }
    }
}
