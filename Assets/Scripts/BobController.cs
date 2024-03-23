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
    public float range=200f;
    public float maxRoamCooldown=1000f;
    private float roamCooldown=0f;
    public RawImage r;
    private float chaseTimer=0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Pause>().isPaused==false)        //If the game isnt paused (Pause.isPaused) does the thing
        {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
        Vector3 left = forward;
        Vector3 right = forward;
        left.x -=15;
        right.x +=15;
        Vector3 position = transform.position;
        position.y -=0.5f;
        Ray see = new Ray(position, forward);
        Ray seeLeft = new Ray(position, left);
        Ray seeRight = new Ray(position, right);
        Debug.DrawRay(position,forward,Color.green);
        Debug.DrawRay(position,left,Color.green);
        Debug.DrawRay(position,right,Color.green);
        if (spottedTarget==false)
        {
            if (Physics.Raycast(see, out RaycastHit hitInfo, range))
            {
                //Debug.Log("Raycast hit");
                if (hitInfo.collider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    spottedTarget=true;
                    Debug.Log("SPOTTED");
                    agent.SetDestination(target.position);  //walk to target
                }else
                {
                    //roam
                    if (roamCooldown==maxRoamCooldown)
                    {
                        Vector3 roamTarget = transform.position;
                        roamTarget.x += UnityEngine.Random.Range(-20,20);
                        roamTarget.z += UnityEngine.Random.Range(-20,20);
                        agent.SetDestination(roamTarget);  //walk to target
                        roamCooldown=0;
                        Debug.Log("Walkin'");
                    }else
                    {
                        roamCooldown++;
                    }  
                    }
            }else
            {
                //roam
                if (roamCooldown==maxRoamCooldown)
                {
                    Vector3 roamTarget = transform.position;
                    roamTarget.x += UnityEngine.Random.Range(-20,20);
                    roamTarget.z += UnityEngine.Random.Range(-20,20);
                    agent.SetDestination(roamTarget);  //walk to target
                    roamCooldown=0;
                    Debug.Log("Walkin'");
                }else
                {
                    roamCooldown++;
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

    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                r.enabled=true;
                Time.timeScale=0;
                }
            }
        }
}
