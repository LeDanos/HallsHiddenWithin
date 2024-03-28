using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody rb;
    private bool isSprinting=false;
    public float runSpeed = 2f;
    public Camera MainCamera;
    public RawImage SprintingOverlay;
    public RawImage StaminaOverlay;
    public float MaxStamina =100;
    private float Stamina;
    public AudioSource walk;
    public AudioSource run;
    public bool interacted=false;
    public bool hidden=false;
    public GameObject startCamera;
    public GameObject playerCamera;
    public bool start=true;
    public bool end=false;
    public GameObject bob;
    public GameObject playerSpawn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Stamina=MaxStamina;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        playerCamera.transform.position=MainCamera.transform.position;
        playerCamera.transform.rotation=MainCamera.transform.rotation;
        MainCamera.transform.position=startCamera.transform.position;
        MainCamera.transform.rotation=startCamera.transform.rotation;
        run.enabled=false;
        walk.enabled=false;
    }
    void Update(){
        if (start==true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Reset Player
                transform.position=playerSpawn.transform.position;
                transform.rotation=playerSpawn.transform.rotation;
                isSprinting=false;
                Stamina=MaxStamina;
                interacted=false;
                hidden=false;
                start=false;
                end=false;
                //Reset Bob
                bob.transform.position=GameObject.Find("Bob").GetComponent<BobController>().patrol[5].position;
                GameObject.Find("Bob").GetComponent<BobController>().spottedTarget=false;
                GameObject.Find("Bob").GetComponent<BobController>().roamCooldown=0;
                GameObject.Find("Bob").GetComponent<BobController>().chaseTimer=0;
                //START
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale=1;
                MainCamera.transform.position=playerCamera.transform.position;
                MainCamera.transform.rotation=playerCamera.transform.rotation;
            }
        }else if(end==true){
            if (Input.GetKeyDown(KeyCode.E))
            {
                start=true;
                end=false;
                MainCamera.transform.position=startCamera.transform.position;
                MainCamera.transform.rotation=startCamera.transform.rotation;
            }
        }else if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&start==false&&end==false)        //If the game isnt paused and player isnt interacted does the thing
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
            Stamina-=0.06f;
        }else
        {
            if (Stamina<MaxStamina)
            {
                Stamina+=0.025f;
            }
        }
        StaminaOverlay.transform.localScale = new Vector3 (1.05f+(Stamina/100),1.05f+(Stamina/100),1);
    }
        }
        
    private void FixedUpdate()
    {
        if (interacted==false&&start==false&&GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&end==false)
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
}