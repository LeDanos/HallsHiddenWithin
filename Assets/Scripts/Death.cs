using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject gameOverCamera;
    public void DeathFunction()
    {
        Time.timeScale=0;
        GameObject.Find("Player").GetComponent<PlayerMovement>().MainCamera.transform.position=gameOverCamera.transform.position;
        GameObject.Find("Player").GetComponent<PlayerMovement>().MainCamera.transform.rotation=gameOverCamera.transform.rotation;
        GameObject.Find("Player").GetComponent<PlayerMovement>().end=true;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Player").GetComponent<PlayerMovement>().run.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().walk.enabled=false;
        GameObject.Find("Bob").GetComponent<TestBobController>().bIdle.enabled=false;
        GameObject.Find("Bob").GetComponent<TestBobController>().bChase.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().isSprinting=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().MainCamera.fieldOfView=60f;
        GameObject.Find("Player").GetComponent<PlayerMovement>().SprintingOverlay.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().Stamina=GameObject.Find("Player").GetComponent<PlayerMovement>().MaxStamina;
        GameObject.Find("Player").GetComponent<PlayerMovement>().open.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().openStart.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().openEnd.enabled=false;
    }
}
