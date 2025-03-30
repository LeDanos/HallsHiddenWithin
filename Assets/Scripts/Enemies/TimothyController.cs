using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class TimothyController : MonoBehaviour
{
    public GameObject Timothy;
    public AudioSource Breathing;
    public Vector3 BreathingPoint;
    public float cooldown=1000;
    private GameObject Door;
    public bool active=false;
    private bool good;
    void Start()
    {
        BreathingPoint=Breathing.transform.position;
    }
    void FixedUpdate()
    {
        if (cooldown>0)
        {
            cooldown--;
        }else if (active==false)
        {
            Spawn();
        }
    }
    public void Spawn(){
        Collider[] around=Physics.OverlapSphere(GameObject.Find("Player").transform.position,20);
        int DoorAmount=0;
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Door"))
            {
                if (hitCollider.GetComponent<DoorInteractable>().isOpen==false)
                {
                    Debug.Log(hitCollider);
                    DoorAmount++;
                }
            }
        }
        Collider[] Doors = new Collider[DoorAmount];
        int DoorCount=0;
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Door"))
            {
                if (hitCollider.GetComponent<DoorInteractable>().isOpen==false)
                {
                    Doors[DoorCount]=hitCollider;
                    DoorCount++;
                }
            }
        }
        Debug.Log(DoorAmount);
        if (DoorAmount!=0)
        {
            Door=Doors[UnityEngine.Random.Range(0, DoorAmount-1)].GameObject();
            Breathing.transform.position=Door.transform.position;
            active=true;
            Debug.Log("Timothy spawn");
        }else
        {
            cooldown=1000;
        }
    }
    void Update()
    {
        if (active==true&&Door.GetComponent<DoorInteractable>().isOpen==true&&Door.GetComponent<DoorInteractable>().interactedByPlayer==true)
        {
            Timothy.GetComponent<TimothyDamage>().EventStart();
            Breathing.transform.position=BreathingPoint;
            active=false;
            cooldown=1000;
            Debug.Log("Timothy despawn");
        }
        if (active==true)
        {
            Collider[] around=Physics.OverlapSphere(GameObject.Find("Player").transform.position,30);
            good=false;
            foreach (var hitCollider in around)
            {
                if (hitCollider.GameObject()==Door)
                {
                    good=true;
                }
            }
            if (good==false)
            {
                Breathing.transform.position=BreathingPoint;
                active=false;
                cooldown=1000;
                Debug.Log("Timothy despawn");
            }
        }
        
    }private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 20);
        Gizmos.DrawWireSphere(transform.position, 30);
    }
}
