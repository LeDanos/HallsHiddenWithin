using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHandRotation : MonoBehaviour
{
    public MeshRenderer front;
    public MeshRenderer left;
    public MeshRenderer right;
    private Vector3 forward;
    private Vector3 localPos;
    void Update()
    {
        forward = GameObject.Find("FlashHand").transform.TransformDirection(Vector3.forward);
        Vector3 toTarget=Vector3.Normalize(Camera.main.transform.position - transform.position);
        localPos = GameObject.Find("FlashHand").transform.InverseTransformPoint(GameObject.Find("Player").transform.position);
        transform.LookAt(Camera.main.transform.position);
        //Debug.Log(localPos.z);
        if (-2<localPos.z&&localPos.z<2)
        {
            front.enabled=true;
            left.enabled=false;
            right.enabled=false;
        }
        else if (localPos.z>0)
        {
            front.enabled=false;
            left.enabled=true;
            right.enabled=false;
        } else
        {
            front.enabled=false;
            left.enabled=false;
            right.enabled=true;
        }
    }
}
