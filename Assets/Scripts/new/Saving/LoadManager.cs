using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour, IDataPersistance
{
    public GameObject Player;
    public GameObject Yellow;
    public GameObject YellowTeleport;
    public GameObject Blue;
    public GameObject BlueTeleport;
    public GameObject Red;
    public GameObject RedTeleport;
    public int zone;
    public void Activate()
    {
        GameObject.Find("Player").GetComponent<PlayerMenus>().start=false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale=1;
        if (zone==0)
        {
            Yellow.SetActive(true);
            Blue.SetActive(false);
            Red.SetActive(false);
            YellowTeleport.GetComponent<TeleportTrigger>().transitionTimer=100;
        }else if (zone==1)
        {
            Yellow.SetActive(false);
            Blue.SetActive(true);
            Red.SetActive(false);
            BlueTeleport.GetComponent<TeleportTrigger>().transitionTimer=100;
            GameObject.Find("Player").GetComponent<Flashlight>().hasFlashlight=true;
        }else if (zone==2)
        {
            Yellow.SetActive(false);
            Blue.SetActive(false);
            Red.SetActive(true);
            RedTeleport.GetComponent<TeleportTrigger>().transitionTimer=100;
            GameObject.Find("Player").GetComponent<Flashlight>().hasFlashlight=true;
        }
    }
    public void LoadData(GameData data){
        this.zone = data.zone;
    }
    public void SaveData(ref GameData data){
        data.zone=this.zone;
    }
}
