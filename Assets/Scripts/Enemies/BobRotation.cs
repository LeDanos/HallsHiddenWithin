using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobRotation : MonoBehaviour
{
    public MeshRenderer front;
    public MeshRenderer back;
    void Update()
    {
        Vector3 toTarget=Vector3.Normalize(Camera.main.transform.position - transform.position);
        transform.LookAt(Camera.main.transform.position);
        if (Vector3.Dot(GameObject.Find("Bob").GetComponent<TestBobController>().forward,toTarget)>0.5)
        {
            front.enabled=true;
            back.enabled=false;
        }else
        {
            back.enabled=true;
            front.enabled=false;
        }
    }
}
