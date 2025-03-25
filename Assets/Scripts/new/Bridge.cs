using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject extention;
    public float levers;
    public GameObject[] lever1;
    public GameObject[] lever2;
    private bool activated1;
    private bool activated2;
    void Start()
    {
        if (levers==0)
        {
            Activate();
        }
    }
    void Update()
    {
        if (levers==1)
        {
            for (int i = 0; i < lever1.Length; i++)
            {
                if (lever1[i].GetComponent<Lever>().activated == true)
                {
                    Activate();
                    break;
                }else
                {
                    Deactivate();
                }
            }
        }else if (levers==2)
        {
            activated1=false;
            activated2=false;
            for (int i = 0; i < levers; i++)
            {
                for (int y = 0; y < lever1.Length; y++)
                {
                    if (lever1[y].GetComponent<Lever>().activated == true)
                    {
                        activated1=true;
                        break;
                    }
                }
                for (int y = 0; y < lever2.Length; y++)
                {
                    if (lever2[y].GetComponent<Lever>().activated == true)
                    {
                        activated2=true;
                        break;
                    }
                }
                if (activated1==true&&activated2==true)
                {
                    Activate();
                }else
                {
                    Deactivate();
                }
            }
        }
    }
    private void Activate(){
        extention.SetActive(true);
    }
    private void Deactivate(){
        extention.SetActive(false);
    }
}
