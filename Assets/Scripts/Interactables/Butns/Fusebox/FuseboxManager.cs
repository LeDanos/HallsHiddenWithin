using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FuseboxManager : MonoBehaviour
{
    [HideInInspector]
    public int fuses;
    void Start()
    {
        fuses=0;
    }
    public void Add(){
        fuses++;
    }
    public void Remove(){
        fuses--;
    }
}
