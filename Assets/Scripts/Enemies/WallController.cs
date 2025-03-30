using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallController : MonoBehaviour
{
    public GameObject[] WallSpawns;
    public GameObject Wall;
    public GameObject EyeController;
    public bool spotted=false;
    public NavMeshAgent agent;
    public AudioSource Idle;
    public AudioSource Alert;
    public Vector3 Target;
    public int openCooldown;
    void Update()
    {
        //Spot player
        if (EyeController.GetComponent<EyesController>().wallActive==true)
        {
            Ray See=new Ray(Wall.transform.position, Wall.transform.forward);
            Debug.DrawRay(Wall.transform.position, Wall.transform.forward, Color.red);
            if (Physics.Raycast(See, out RaycastHit hitInfo)&&hitInfo.collider.CompareTag("Player"))
            {
            }
            Collider[] around=Physics.OverlapSphere(Wall.transform.position,40);
            foreach (var hitCollider in around)
            {
                if (hitCollider.CompareTag("Player")&&GameObject.Find("Player").GetComponent<PlayerMovement>().hidden==false)
                {
                    if (Vector3.Dot(Wall.transform.forward,GameObject.Find("Player").transform.position)>0.6)
                    {
                        Vector3 toPlayer = GameObject.Find("Player").transform.position-Wall.transform.position;
                        Ray toPlayerRay =new Ray(Wall.transform.position,toPlayer);
                        Debug.DrawRay(Wall.transform.position,toPlayer,Color.red);
                        if (Physics.Raycast(toPlayerRay, out RaycastHit shitInfo)&&shitInfo.collider.CompareTag("Player"))
                        {
                            spotted=true;
                            Alert.enabled=true;
                            Debug.Log("Wall spotted, youre fucked.");
                        }
                    }
                }
            }
            if (hitInfo.collider.CompareTag("Door"))
            {
                if (openCooldown<60)
                {
                    openCooldown++;
                }else{
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        if (hitInfo.collider.gameObject.tag=="Door")
                        {
                            hitInfo.collider.gameObject.GetComponent<DoorInteractable>().interactedByPlayer=false;
                        }
                        interactObj.Interact();
                    }
                }
            }
        }
        //Go after player
        if (spotted==true)
        {
            agent.SetDestination(GameObject.Find("Player").transform.position);
        }
        //Disable
        if (spotted==false&&EyeController.GetComponent<EyesController>().wallActive==true&&Wall.transform.position.x==Target.x&&Wall.transform.position.z==Target.z)
        {
            Despawn();
        }
    }
    public void Spawn(){
        int farthestWall=0;
        float farthestDistance=0;
        for (int i = 0; i < WallSpawns.Length; i++)
        {
            float distance=Vector3.Distance(WallSpawns[i].transform.position, GameObject.Find("Player").transform.position);
            if (i==0)
            {
                farthestWall=i;
                farthestDistance=distance;
            }else if (farthestDistance<distance)
            {
                farthestWall=i;
                farthestDistance=distance;
            }
        }
        Wall.transform.position=WallSpawns[farthestWall].transform.position;
        EyeController.GetComponent<EyesController>().wallActive=true;
        Target=GameObject.Find("Player").transform.position;
        agent.SetDestination(Target);
        Idle.enabled=true;
    }
    public void Despawn(){
        EyeController.GetComponent<EyesController>().wallActive=false;
        Idle.enabled=false;
        Alert.enabled=false;
        Wall.SetActive(false);
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Death>().DeathFunction();
        }
    }
}
