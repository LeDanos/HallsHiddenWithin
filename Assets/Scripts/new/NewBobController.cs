using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TestBobController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public bool spottedTarget=false;
    public float maxRoamCooldown=500f;
    public float roamCooldown=0f;
    public Transform[] patrol;
    public Transform[] endPatrol;
    private float openCooldown=0f;
    public AudioSource bIdle;
    public AudioSource bChase;
    public AudioSource bAlert;
    public Transform start;
    public float attentionSpan;
    public Vector3 forward;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().start==false&&GameObject.Find("Player").GetComponent<PlayerMenus>().end==false)        //If the game isnt paused (Pause.isPaused) does the thing
        {
        forward = transform.TransformDirection(Vector3.forward);
        Vector3 position = transform.position;
        position.y -=0.5f;

        //Forward raycast stuff
        Ray see = new Ray(position, forward);
        Debug.DrawRay(position,forward,Color.green);

        if (spottedTarget==false)
        {
        // ---------------------------Forward Raycast---------------------------------
            if (Physics.Raycast(see, out RaycastHit hitInfo, 5))
            {
                if (hitInfo.collider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    if (spottedTarget==false)
                    {
                        bAlert.enabled=true;
                    }
                    spottedTarget=true;
                    Debug.Log("SPOTTED");
                    agent.SetDestination(target.position);  //walk to target
                }else
                {
                    InFrontScan(position,forward);
                    AroundScan(position);
                    if (spottedTarget==false)
                    {
                        Roam();
                    }
                }
                //Open doors
                if (hitInfo.collider.CompareTag("Door"))
                {
                    if (openCooldown<80)
                    {
                        openCooldown++;
                    }else{
                        if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                        {
                        interactObj.Interact();
                        }
                    }
                }
                if (hitInfo.collider.CompareTag("Locked Door")&&GameObject.Find("Locked Door").GetComponent<LockedDoorInteractable>().hasKey==true)
                {
                    if (openCooldown<80)
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
                AroundScan(position);
                if (spottedTarget==false)
                {
                    Roam();
                }
            }
        }else
        {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
            {
                agent.SetDestination(target.position);  //walk to target
            }
            else
            {
                    bAlert.enabled=false;
                    spottedTarget=false;
                    roamCooldown=maxRoamCooldown/2;
                    Debug.Log("Unspotted");
            }
        }
    Sounds(position);
    }}

//--------------------------------------------------------------------------------------------------------------
    private void InFrontScan(Vector3 position,Vector3 forward){
        Collider[] around=Physics.OverlapSphere(position,20);
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
            {
                Vector3 toTarget=Vector3.Normalize(target.position - transform.position);
                if (Vector3.Dot(forward,toTarget)>0.6)
                {
                    Vector3 toPlayer = target.position-position;
                    Ray toPlayerRay =new Ray(position,toPlayer);
                    Debug.DrawRay(position,toPlayer,Color.red);
                    if (Physics.Raycast(toPlayerRay, out RaycastHit shitInfo)&&shitInfo.collider.CompareTag("Player"))
                    {
                        if (spottedTarget==false)
                        {
                            bAlert.enabled=true;
                        }
                        spottedTarget=true;
                        Debug.Log("SPOTTED");
                        agent.SetDestination(target.position);  //walk to target
                    }
                }
            }
        }
    }

    private void AroundScan(Vector3 position){
        Collider[] around=Physics.OverlapSphere(position,4);
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
            {
                Vector3 toPlayer = target.position-position;
                Ray toPlayerRay =new Ray(position,toPlayer);
                Debug.DrawRay(position,toPlayer,Color.red);
                if (Physics.Raycast(toPlayerRay, out RaycastHit shitInfo)&&shitInfo.collider.CompareTag("Player"))
                {
                    if (spottedTarget==false)
                    {
                        bAlert.enabled=true;
                    }
                    spottedTarget=true;
                    Debug.Log("SPOTTED");
                    agent.SetDestination(target.position);  //walk to target
                }
            }
        }
    }

    private void Roam(){
        if (roamCooldown==maxRoamCooldown){
                 
                int roam = UnityEngine.Random.Range(0,patrol.Length);
                Vector3 roamTarget = patrol[roam].position;
                agent.SetDestination(roamTarget);  //walk to target
                roamCooldown=0;
                Debug.Log("Walkin'");
        }else{
            roamCooldown++;
        }
    }

    public void GoTo(Transform point){
        if (spottedTarget==false)
        {
            roamCooldown=0;
            agent.SetDestination(point.position);
        }
    }

    public void Restart(){
        spottedTarget=false;
        roamCooldown=0;
        transform.position=start.position;
        agent.SetDestination(start.position);
    }

    //-----------------------------------------------------------------------------------------------------

    private void Sounds(Vector3 position){
        Collider[] around=Physics.OverlapSphere(position,30);
        var heading = target.position - position;
        var distance = heading.magnitude;
        bool e=false;
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Player")&&e==false){
                e=true;
            }
        }
        if (e==true)
        {
            if (spottedTarget==false)
            {
                bIdle.volume=2/(distance/5);
                bIdle.enabled=true;
                bChase.enabled=false;
            }else{
                bChase.volume=2/(distance/5);
                bIdle.enabled=false;
                bChase.enabled=true;
            }
        }else{
            bIdle.enabled=false;
            bChase.enabled=false;
        }
    }

    //-----------------------------------------------------------------------------------------------------

    private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    GameObject.Find("Player").GetComponent<Death>().DeathFunction();
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
}
