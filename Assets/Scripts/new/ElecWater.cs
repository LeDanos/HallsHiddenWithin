using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecWater : MonoBehaviour
{
    public MeshRenderer electricity;
    public GameObject[] lever;
    public float cooldown = 0;
    public bool activated = false;
    void Start()
    {
        if (lever.Length==0)
        {
            Activate();
        }
    }
    void Update()
    {
        if (lever.Length>0)
        {
            for (int i = 0; i < lever.Length; i++)
            {
                if (lever[i].GetComponent<Lever>().activated == true)
                {
                    Activate();
                    break;
                }
                Deactivate();
            }
        }
    }
    void FixedUpdate()
    {
        if (cooldown>0)
        {
            cooldown--;
        }
    }
    private void Activate(){
        electricity.enabled=true;
        activated=true;
    }
    private void Deactivate(){
        electricity.enabled=false;
        activated=false;
    }
}
