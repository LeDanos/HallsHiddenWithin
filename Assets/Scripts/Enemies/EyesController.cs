using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    public bool active=false;
    public bool wallActive=false;
    public GameObject[] Eyes;
    public int eyesActive;
    private int spawnTimer;
    void Start()
    {
        eyesActive=0;
        spawnTimer=1000;
    }
    void Update()
    {
        if (spawnTimer==0&&active==true)
        {
            if (eyesActive<Eyes.Length)
            {
                for (int i = 0; i < 1; i++)
                {
                    int random = Random.Range(0, Eyes.Length);
                    if (Eyes[random].GetComponent<EyeTrigger>().active==false)
                    {
                        Eyes[random].GetComponent<EyeTrigger>().Activate();
                    }else
                    {
                        i--;
                    }
                }
                spawnTimer=1000;
            }else
            {
                spawnTimer=10000;
            }
        }
    }
    void FixedUpdate()
    {
        if (spawnTimer>0&&active==true)
        {
            spawnTimer--;
        }
    }
}
