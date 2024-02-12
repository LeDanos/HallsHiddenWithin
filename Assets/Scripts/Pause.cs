using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public Canvas PausedOverlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused==false)
            {
                isPaused=true;
                PausedOverlay.enabled=true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Paused");
                Time.timeScale=0;
            }
            else if (isPaused==true)
            {
                isPaused=false;
                PausedOverlay.enabled=false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Unpaused");
                Time.timeScale=1;
            }
        };
    }
}
