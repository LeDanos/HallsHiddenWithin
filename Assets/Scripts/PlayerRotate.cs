using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().start==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().end==false)    //If the game isnt paused (Pause.isPaused) does the thing
        {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (transform.rotation.x>0.6f)
        {
            transform.Rotate(-0.6f, h, 0);
        }else if (transform.rotation.x<-0.6f)
        {
            transform.Rotate(0.6f, h, 0);
        }else
        {
            transform.Rotate(v, h, 0);
        } 
        }
    }
}
