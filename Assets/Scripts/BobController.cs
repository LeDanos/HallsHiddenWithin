using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BobController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public bool spottedTarget=false;
    public float range=150f;
    public float maxRoamCooldown=1000f;
    private float roamCooldown=0f;
    public RawImage r;
    private float chaseTimer=0f;
    public Transform[] patrol;
    private float openCooldown=0f;
    public GameObject gameOverCamera;
    public Camera playerCamera;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false)        //If the game isnt paused (Pause.isPaused) does the thing
        {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
        Vector3 position = transform.position;
        position.y -=0.5f;

        //Forward raycast stuff
        Ray see = new Ray(position, forward);
        Debug.DrawRay(position,forward,Color.green);

        if (spottedTarget==false)
        {
        // ---------------------------Forward Raycast---------------------------------
            if (Physics.Raycast(see, out RaycastHit hitInfo, range))
            {
                if (hitInfo.collider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    spottedTarget=true;
                    Debug.Log("SPOTTED");
                    agent.SetDestination(target.position);  //walk to target
                }else
                {
                    InFrontScan(position,forward);
                    if (spottedTarget==false)
                    {
                        Roam();
                    }
                    //Roam();
                }
                //Open doors
                if (hitInfo.collider.CompareTag("Door"))
                {
                    if (openCooldown<1000)
                    {
                        openCooldown++;
                    }else{
                        if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                        {
                        interactObj.Interact();
                        }
                    }
                }
            }else
            {
                InFrontScan(position,forward);
                if (spottedTarget==false)
                {
                    Roam();
                }
            }
        }else
        {
            if (chaseTimer<1000)
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    agent.SetDestination(target.position);  //walk to target
                    chaseTimer++;
                }
                else
                {
                    chaseTimer=0;
                    spottedTarget=false;
                    roamCooldown=maxRoamCooldown/2;
                    Debug.Log("Unspotted");
                }
            }else
            {
                chaseTimer=0;
                spottedTarget=false;
                roamCooldown=maxRoamCooldown/2;
                Debug.Log("Unspotted");
            }
        }
    }}

//--------------------------------------------------------------------------------------------------------------
    private void InFrontScan(Vector3 position,Vector3 forward){
        Collider[] around=Physics.OverlapSphere(position,20);
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
            {
                if (Vector3.Dot(forward,target.position)>0.7)
                {
                    Vector3 toPlayer = target.position-position;
                    Ray toPlayerRay =new Ray(position,toPlayer);
                    Debug.DrawRay(position,toPlayer,Color.red);
                    if (Physics.Raycast(toPlayerRay, out RaycastHit shitInfo)&&shitInfo.collider.CompareTag("Player"))
                    {
                        spottedTarget=true;
                        Debug.Log("SPOTTED");
                        agent.SetDestination(target.position);  //walk to target
                    }
                }
            }
        }
    }

    private void Roam(){
        if (roamCooldown==maxRoamCooldown)
                {
                    int roam = UnityEngine.Random.Range(0,patrol.Length);
                    Vector3 roamTarget = patrol[roam].position;
                    agent.SetDestination(roamTarget);  //walk to target
                    roamCooldown=0;
                    Debug.Log("Walkin'");
                }else
                {
                    roamCooldown++;
                }
    }

    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                Time.timeScale=0;
                playerCamera.transform.position=gameOverCamera.transform.position;
                playerCamera.transform.rotation=gameOverCamera.transform.rotation;
                GameObject.Find("Player").GetComponent<PlayerMovement>().interacted=true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                }
            }
        }
}
