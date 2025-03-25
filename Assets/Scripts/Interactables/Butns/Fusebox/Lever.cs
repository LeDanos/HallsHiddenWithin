using TMPro;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable{
    public GameObject[] RequiredFuses;
    public int good;
    public int goody;
    public bool activated;
    public MeshRenderer leverOff;
    public MeshRenderer leverOn;
    private int wait=0;
    public void Interact(){
        if (wait==0)
        {
            good=0;
            if (activated==false)
            {
                for (int i = 0; i < RequiredFuses.Length; i++)
                {
                    if (RequiredFuses[i].GetComponent<Fuse>().Active==true)
                    {
                        good++;
                    }else
                    {
                        Debug.Log(good+"/"+RequiredFuses.Length);
                        break;
                    }
                }
                if (good==RequiredFuses.Length)
                {
                    On();
                } 
            }else
            {
                Off();
            }
            wait=10;
        }
    }
    public void On(){
        Debug.Log("Good :)");
        activated=true;
        leverOff.enabled=false;
        leverOn.enabled=true;
    }
    public void Off(){
        Debug.Log("off");
        activated=false;
        leverOff.enabled=true;
        leverOn.enabled=false;
    }
    void Update()
    {
        if (activated==true)
        {
            goody=0;
            for (int i = 0; i < RequiredFuses.Length; i++)
            {
                if (RequiredFuses[i].GetComponent<Fuse>().Active==true)
                {
                    goody++;
                }else
                {
                    Debug.Log(goody+"/"+RequiredFuses.Length);
                    break;
                }
            }
            if (good!=RequiredFuses.Length)
            {
                Off();
            } 
        }
    }
    void FixedUpdate()
    {
        if (wait>0)
        {
            wait--;
        }
    }
}