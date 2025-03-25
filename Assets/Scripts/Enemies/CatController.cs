using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool active=false;
    public bool spawned=true;
    public MeshRenderer normal;
    public MeshRenderer catfighter;
    public ParticleSystem particles;
    public int cooldown = 0;
    public int timer = 100;
    public GameObject cat;
    private Vector3 ogPosition;
    public AudioSource[] meows;
    public AudioSource boom;
    private int[] meowTriggers=new int[11];
    void Start()
    {
        ogPosition=cat.transform.position;
        meowTriggers[0]=100;
        meowTriggers[1]=60;
        meowTriggers[2]=30;
        meowTriggers[3]=15;
        meowTriggers[4]=10;
        meowTriggers[5]=5;
        meowTriggers[6]=3;
        meowTriggers[7]=1;
    }
    void FixedUpdate()
    {
        if (cooldown>0)
        {
            cooldown--;
            if (cooldown==0)
            {
                Respawn();
            }
        }
        if (active==true&&timer>0)
        {
            for (int i = 0; i < meowTriggers.Length; i++)
            {
                if (timer==meowTriggers[i])
                {
                    Meow();
                }
            }
            timer--;
            if (timer==0)
            {
                particles.transform.position=cat.transform.position;
                particles.Play();
                Boom();
            }
        }
    }
    public void Activate(){
        if (spawned==true)
        {
            active=true;
            agent.SetDestination(GameObject.Find("Player").transform.position);
        }
    }
    public void Boom()
    {
        boom.enabled=true;
        active=false;
        timer=100;
        Collider[] around=Physics.OverlapSphere(normal.transform.position,5);
        foreach (var hitCollider in around)
        {
            if (hitCollider.CompareTag("Player"))
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().Damage();
                break;
            }
        }
        normal.enabled=false;
        catfighter.enabled=false;
        spawned=false;
        cooldown=200;
    }
    public void Respawn(){
        if (Random.Range(1,10)==5)
        {
            catfighter.enabled=true;
        }else
        {
            normal.enabled=true;
        }
        cat.transform.position=ogPosition;
        agent.SetDestination(ogPosition);
        particles.Stop();
        boom.enabled=false;
        spawned=true;
    }
    public void Meow()
    {
        foreach (var item in meows)
        {
            item.enabled=false;
        }
        meows[Random.Range(0,meows.Length)].enabled=true;
    }
}
