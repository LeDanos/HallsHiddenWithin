using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    public bool activated=false;
    public RawImage transition;
    public int transitionTimer=0;
    public GameObject transitionPoint;
    public int teleportZone;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")&&activated==false)
        {
            activated=true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().hidden=true;
        }
    }
    void FixedUpdate()
    {
        if (activated==true&&transitionTimer<100)
        {
            transitionTimer++;
            if (teleportZone==0)
            {
                transition.color=new Color(0f,0f,0f,0.01f*transitionTimer);
            }else
            {
                transition.color=new Color(1f,1f,1f,0.01f*transitionTimer);
            }
        }else if (activated==true&&transitionTimer==100)
        {
            GameObject.Find("Player").GetComponent<LoadManager>().zone=teleportZone;
            DataPersistanceManager.instance.SaveGame();
            GameObject.Find("Player").GetComponent<LoadManager>().Activate();
            activated=false;
        }else if (activated==false&&transitionTimer>0)
        {
            if (transitionTimer==99)
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().hidden=false;
                GameObject.Find("Player").transform.position=transitionPoint.transform.position;
                if (teleportZone==2)
                {
                    GameObject.Find("Eyes").GetComponent<EyesController>().active=true;
                }
            }
            transitionTimer--;
            if (teleportZone==0)
            {
                transition.color=new Color(0f,0f,0f,0.01f*transitionTimer);
            }else
            {
                transition.color=new Color(1f,1f,1f,0.01f*transitionTimer);
            }
        }
    }
}
