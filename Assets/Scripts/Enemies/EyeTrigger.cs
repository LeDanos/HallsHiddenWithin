using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EyeTrigger : MonoBehaviour
{
    public MeshRenderer Eye;
    public GameObject Wall;
    public GameObject EyeController;
    public GameObject EyeTriggerer;
    public bool active=false;
    public void Activate(){
        active=true;
        Eye.enabled=true;
        EyeTriggerer.SetActive(true);
        EyeController.GetComponent<EyesController>().eyesActive++;
        Debug.Log("Eye Activated");
    }
    public void Deactivate(){
        active=false;
        Eye.enabled=false;
        EyeTriggerer.SetActive(false);
        EyeController.GetComponent<EyesController>().eyesActive--;
        Debug.Log("Eye Deactivated");
    }
    public void Triggering()
    {
            Debug.Log("Wall spawned RUN");
            Wall.SetActive(true);
            Wall.GetComponent<WallController>().Spawn();
            Deactivate();
    }
}
