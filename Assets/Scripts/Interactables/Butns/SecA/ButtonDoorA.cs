using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonDoorA : MonoBehaviour, IInteractable{
    public BoxCollider Button;
    public GameObject Door;
    public GameObject OpenButton;
    public GameObject CloseButton;
    public Light ScreenLight;
    public GameObject FlashHand;
    public GameObject Lights;
    public void Interact(){
        Door.transform.position=new Vector3(Door.transform.position.x,Door.transform.position.y+4,Door.transform.position.z);
        OpenButton.GetComponent<ButtonOpenA>().TurnOff();
        CloseButton.GetComponent<ButtonCloseA>().TurnOff();
        Button.enabled=false;
        Lights.GetComponent<Power>().PowerOff();
        Lights.GetComponent<Power>().work=true;
        FlashHand.SetActive(true);
        ScreenLight.enabled=false;
    }
    public void TurnOn(){
        Button.enabled=true;
    }
    public void TurnOff(){
        Button.enabled=false;
    }
}