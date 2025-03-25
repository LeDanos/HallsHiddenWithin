using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitManager : MonoBehaviour
{
    public int wait;
    public GameObject Keypad;
    void Start()
    {
        wait=0;
    }
    public void Restart(){
        wait=0;
        Debug.Log("Wait restarted");
    }
}
