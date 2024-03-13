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
    public float range=100f;
    public float maxRoamCooldown=1000f;
    private float roamCooldown=0f;
    public RawImage r;
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
        Ray see = new Ray(transform.position, forward);
        Debug.DrawRay(transform.position,forward,Color.green);
        if (spottedTarget==false)
        {
            if (Physics.Raycast(see, out RaycastHit hitInfo, range))
            {
                //Debug.Log("Raycast hit");
                if (hitInfo.collider.CompareTag("Player"))
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
            agent.SetDestination(target.position);  //walk to target
        }
    }}

    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                r.enabled=true;
                Time.timeScale=0;
            }
        }
}
