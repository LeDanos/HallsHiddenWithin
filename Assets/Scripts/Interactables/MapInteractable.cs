using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractable : MonoBehaviour, IInteractable{
    public MeshRenderer map;
    public BoxCollider mapC;
    public Light spotLight;
    public void Interact(){
        map.enabled=false;
        GameObject.Find("Player").GetComponent<Map>().hasMap=true;
        mapC.enabled=false;
        spotLight.enabled=false;
        GameObject.Find("Map").GetComponent<MapInteractable>().enabled=false;
    }
}