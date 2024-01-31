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
    public float MaxStamina =1000;
    private float Stamina;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Stamina=MaxStamina;
    }
    void Update(){
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
            Stamina-=0.1f;
        }else
        {
            if (Stamina<MaxStamina)
            {
                Stamina+=0.05f;
            }
        }
        StaminaOverlay.transform.localScale = new Vector3 (1+(Stamina/100),1+(Stamina/100),1);
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 verticalMovement = transform.forward * moveSpeed * verticalInput;
        Vector3 horizontalMovement = transform.right * moveSpeed * horizontalInput;
        
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
            }
        }

        Vector3 movement = verticalMovement + horizontalMovement;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}