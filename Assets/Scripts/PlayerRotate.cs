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
    private float h;
    private float v;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().start==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().interacted==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().end==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().win==false&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)    //If the game isnt paused (Pause.isPaused) does the thing
        {
        h += horizontalSpeed * Input.GetAxis("Mouse X");

        v += verticalSpeed * Input.GetAxis("Mouse Y");
        v = Mathf.Clamp (v, -45, 45);

        transform.eulerAngles = new Vector3(v, 90f+h, 0.0f);
        }
    }
}
