using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody rb;
    private Boolean isSprinting=false;
    public float runSpeed = 2f;
    public Camera MainCamera;
    public RawImage SprintingOverlay;
    public RawImage StaminaOverlay;
    public RawImage r;
    public float MaxStamina =100;
    private float Stamina;
    public AudioSource walk;
    public AudioSource run;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Stamina=MaxStamina;
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update(){
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false)        //If the game isnt paused (Pause.isPaused) does the thing
        {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprint on");
            isSprinting=true;
            MainCamera.fieldOfView=70f;
            SprintingOverlay.enabled=true;


        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Sprint off");
            isSprinting=false;
            MainCamera.fieldOfView=60f;
            SprintingOverlay.enabled=false;
        };
        if (isSprinting==true)
        {
            Stamina-=0.05f;
        }else
        {
            if (Stamina<MaxStamina)
            {
                Stamina+=0.025f;
            }
        }
        StaminaOverlay.transform.localScale = new Vector3 (1+(Stamina/100),1+(Stamina/100),1);
        if (Input.GetKeyDown(KeyCode.R))
        {
            r.enabled=true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            r.enabled=false;
        }
    }
    }
    private void FixedUpdate()
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
                MainCamera.fieldOfView=60f;
                SprintingOverlay.enabled=false;
                run.enabled=false;
                walk.enabled=true;
            }
        }

        Vector3 movement = verticalMovement + horizontalMovement;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}