using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenus : MonoBehaviour
{
    public GameObject startCamera;
    public GameObject playerCamera;
    public bool start=true;
    public bool end=false;
    public bool win=false;
    public AudioSource openStart;
    public AudioSource open;
    public AudioSource openEnd;

    void Update()
    {
        if (start==true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DataPersistanceManager.instance.NewGame();
                GameObject.Find("Player").GetComponent<LoadManager>().zone=0;
                GameObject.Find("Player").GetComponent<LoadManager>().Activate();
            Camera.main.transform.position = playerCamera.transform.position;
            Camera.main.transform.rotation = playerCamera.transform.rotation;
            }else if (Input.GetKeyDown(KeyCode.R))
            {
                DataPersistanceManager.instance.LoadGame();
                GameObject.Find("Player").GetComponent<LoadManager>().Activate();
                Camera.main.transform.position = playerCamera.transform.position;
                Camera.main.transform.rotation = playerCamera.transform.rotation;
            }else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }/*else if (Input.GetKeyDown(KeyCode.G))        -For testing the win area (press G to win)
            {
                MainCamera.transform.position=winCamera.transform.position;
                MainCamera.transform.rotation=winCamera.transform.rotation;
            }*/
        }else if(end==true||win==true){
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
