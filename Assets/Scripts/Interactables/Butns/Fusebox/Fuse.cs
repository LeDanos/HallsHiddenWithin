using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour, IInteractable{
    public bool activateOnStart;
    private bool active;
    public bool Active {
        get { return active;}
        set { active = value;
            Debug.Log(active);}
    }
    public GameObject fusebox;
    public MeshRenderer fuse;
    public GameObject lever;
    private int wait=0;
    void Start()
    {
        Active=false;
        if (activateOnStart==true)
        {
            fusebox.GetComponent<FuseboxManager>().Add();
            Interact();
            lever.GetComponent<Lever>().Interact();
        }
    }
    public void Interact(){
        if (wait==0)
        {
            if (Active==false)
            {
                if (fusebox.GetComponent<FuseboxManager>().fuses>0)
                {
                    fusebox.GetComponent<FuseboxManager>().Remove();
                    Active=true;
                    fuse.enabled=true;
                    Debug.Log("Fuse activated");
                }
            }else
            {
                fusebox.GetComponent<FuseboxManager>().Add();
                Active=false;
                fuse.enabled=false;
                lever.GetComponent<Lever>().Interact();
                Debug.Log("Fuse deactivated");
            }
            wait=10; 
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
