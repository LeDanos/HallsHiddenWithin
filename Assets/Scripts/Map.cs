using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour{
    public Canvas MapOverlay;
    public RawImage[] MapImage;
    public AudioSource walk;
    public AudioSource run;
    public bool hasMap = false;
    public bool onMap=false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)&&GameObject.Find("Player").GetComponent<PlayerMovement>().start==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().end==false&&hasMap==true)
        {
            if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false)
            {
                GameObject.Find("Player").GetComponent<Pause>().isPaused=true;
                MapOverlay.enabled=true;
                onMap=true;
                MapImage[GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().correctCode].enabled=true;
                Debug.Log("Paused: Map");
                run.enabled=false;
                walk.enabled=false;
                GameObject.Find("Main Camera").GetComponent<Pixelation>().BlockCount=480;
            }
            else if (GameObject.Find("Player").GetComponent<Pause>().isPaused==true&&onMap==true)
            {
                GameObject.Find("Player").GetComponent<Pause>().Continue();

            }
        };
    }
}
