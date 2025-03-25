using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject gameOverCamera;
    public void DeathFunction()
    {
        Time.timeScale=0;
        Camera.main.transform.position=gameOverCamera.transform.position;
        Camera.main.transform.rotation=gameOverCamera.transform.rotation;
        GameObject.Find("Player").GetComponent<PlayerMenus>().end=true;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Player").GetComponent<PlayerMovement>().run.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().walk.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().isSprinting=false;
        Camera.main.fieldOfView=60f;
        GameObject.Find("Player").GetComponent<PlayerMovement>().SprintingOverlay.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().Stamina=GameObject.Find("Player").GetComponent<PlayerMovement>().MaxStamina;
        GameObject.Find("Player").GetComponent<PlayerMenus>().open.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMenus>().openStart.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMenus>().openEnd.enabled=false;
    }
}
