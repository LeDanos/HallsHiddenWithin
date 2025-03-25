using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody rb;
    public bool isSprinting=false;
    public float runSpeed = 2f;
    public RawImage SprintingOverlay;
    public RawImage StaminaOverlay;
    public float MaxStamina =100;
    public float Stamina;
    public AudioSource walk;
    public AudioSource run;
    public bool interacted=false;
    public bool hidden=false;
    public bool damaged=false;
    public RawImage damageOverlay;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Stamina=MaxStamina;
        Camera.main.transform.position=GameObject.Find("Player").GetComponent<PlayerMenus>().startCamera.transform.position;
        Camera.main.transform.rotation=GameObject.Find("Player").GetComponent<PlayerMenus>().startCamera.transform.rotation;
        run.enabled=false;
        walk.enabled=false;
    }
    void Update(){
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().start==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().end==false)
        {        //If the game isnt paused and player isnt interacted does the thing
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprint on");
            isSprinting=true;
            Camera.main.fieldOfView=70f;
            SprintingOverlay.enabled=true;


        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Sprint off");
            isSprinting=false;
            Camera.main.fieldOfView=60f;
            SprintingOverlay.enabled=false;
        };
        StaminaOverlay.transform.localScale = new Vector3 (1.05f+(Stamina/100),1.05f+(Stamina/100),1);
    }
        }
        
    private void FixedUpdate()
    {
        if (interacted==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().start==false&&GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().end==false)
        {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 verticalMovement = transform.forward * moveSpeed * verticalInput;
        Vector3 horizontalMovement = transform.right * moveSpeed * horizontalInput;
        
        if (verticalInput>0.1||horizontalInput>0.1||verticalInput<-0.1||horizontalInput<-0.1)
        {
            if (isSprinting==true)
            {
                walk.enabled=false;
                run.enabled=true;
            }else
            {
                run.enabled=false;
                walk.enabled=true;
            }
        }else
        {
            walk.enabled=false;
            run.enabled=false;
        }
        
        if (isSprinting==true)
        {
            if (Stamina>0)
            {
                horizontalMovement *= runSpeed;
                verticalMovement *= runSpeed;
            }else
            {
                Debug.Log("Sprint off");
                isSprinting=false;
                Camera.main.fieldOfView=60f;
                SprintingOverlay.enabled=false;
                run.enabled=false;
                walk.enabled=true;
            }
        }

        if (isSprinting==true)
        {
            Stamina-=0.3f;
        }else
        {
            if (Stamina<MaxStamina)
            {
                Stamina+=0.1f;
            }
        }

        Vector3 movement = verticalMovement + horizontalMovement;
        if (verticalInput!=0&&horizontalInput!=0)
        {
            movement /= 3;
            movement *= 2;
        }

        //rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);        old bad movePosition
        rb.velocity = movement;                                             //  good new velocity
        }
        
    }
    public void Stop(){
        rb.velocity=rb.velocity*0;
    }
    public void Damage(){
        if (damaged==false)
        {
            damaged=true;
            damageOverlay.enabled=true;
        }else
        {
            damageOverlay.enabled=false;
            GameObject.Find("Player").GetComponent<Death>().DeathFunction();
        }
    }
}