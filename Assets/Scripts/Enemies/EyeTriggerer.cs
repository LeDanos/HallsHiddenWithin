using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTriggerer : MonoBehaviour
{
    public GameObject EyeTrigger;
    public GameObject EyeController;
    void OnTriggerEnter(Collider other)
    {
        if (EyeTrigger.GetComponent<EyeTrigger>().active==true&&other.gameObject.CompareTag("Player")&&EyeController.GetComponent<EyesController>().wallActive==false)
        {
            EyeTrigger.GetComponent<EyeTrigger>().Triggering();
        }
    }
}
