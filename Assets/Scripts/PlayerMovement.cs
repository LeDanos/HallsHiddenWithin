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
    public Camera MainCamera;
    public RawImage SprintingOverlay;
    public RawImage StaminaOverlay;
    public float MaxStamina =100;
    public float Stamina;
    public AudioSource walk;
    public AudioSource run;
    public bool interacted=false;
    public bool hidden=false;
    public GameObject startCamera;
    public GameObject winCamera;
    public GameObject playerCamera;
    public bool start=true;
    public bool end=false;
    public bool win=false;
    public GameObject bob;
    public GameObject gob;
    public GameObject playerSpawn;
    public AudioSource openStart;
    public AudioSource open;
    public AudioSource openEnd;

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
                open.enabled=false;
                openStart.enabled=false;
                openEnd.enabled=false;
                GameObject.Find("Player").GetComponent<Map>().hasMap=false;

                /*
                //Reset Items
                GameObject.Find("Key").GetComponent<KeyInteractable>().enabled=true;
                GameObject.Find("Locked Door").GetComponent<LockedDoorInteractable>().hasKey=false;         <---- A lot of useless shit because me stupid :)
                GameObject.Find("Keycard").GetComponent<KeycardInteractable>().enabled=true;
                GameObject.Find("Keycard Scan").GetComponent<KeycardScanInteractable>().Restart();
                GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().Restart();
                //Reset Doors
                GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
                foreach (var door in doors)
                {
                    door.GetComponent<DoorInteractable>().Restart();
                }
                GameObject.Find("Locked Door").GetComponent<LockedDoorInteractable>().Restart();
                GameObject.Find("Keycard Scan").GetComponent<KeycardScanInteractable>().Restart();
                //Reset Bob
                bob.GetComponent<BobController>().Restart();
                //Reset Gob
                gob.GetComponent<BobController>().Restart();
                */

                //START
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale=1;
                MainCamera.transform.position=playerCamera.transform.position;
                MainCamera.transform.rotation=playerCamera.transform.rotation;
            }else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }/*else if (Input.GetKeyDown(KeyCode.R))        -For testing the win area
            {
                MainCamera.transform.position=winCamera.transform.position;
                MainCamera.transform.rotation=winCamera.transform.rotation;
            }*/
        }else if(end==true||win==true){
            if (Input.GetKeyDown(KeyCode.E))
            {
                start=true;
                end=false;
                win=false;
                MainCamera.transform.position=startCamera.transform.position;
                MainCamera.transform.rotation=startCamera.transform.rotation;
                SceneManager.LoadScene("Main");
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

        //rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);        old bad movePosition
        rb.velocity = movement;                                             //  good new velocity
        }
        
    }
}