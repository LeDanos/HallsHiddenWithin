using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public Canvas PausedOverlay;
    public AudioSource walk;
    public AudioSource run;
    public Camera MainCamera;
    public GameObject StartCamera;
    public Canvas MapOverlay;
    public AudioSource idle;
    public AudioSource chase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&GameObject.Find("Player").GetComponent<PlayerMovement>().start==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().end==false)
        {
            if (isPaused==false)
            {
                isPaused=true;
                PausedOverlay.enabled=true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Paused");
                Time.timeScale=0;
                run.enabled=false;
                walk.enabled=false;
                idle.enabled=false;
                chase.enabled=false;
            }
            else if (isPaused==true)
            {
                Continue();
            }
        };
    }

    public void Continue(){
        if (GameObject.Find("Player").GetComponent<Map>().onMap==true)
        {
            MapOverlay.enabled=false;
            GameObject.Find("Main Camera").GetComponent<Pixelation>().BlockCount=180;
        }
        isPaused=false;
        PausedOverlay.enabled=false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Unpaused");
        Time.timeScale=1;
    }

    public void ToMenu(){
        isPaused=false;
        PausedOverlay.enabled=false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().start=true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().end=false;
        MainCamera.transform.position=StartCamera.transform.position;
        MainCamera.transform.rotation=StartCamera.transform.rotation;
    }
}
