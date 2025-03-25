using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int zone;
    public bool transition;

    public GameData(){
        zone=0;
        transition=false;
    }
}
