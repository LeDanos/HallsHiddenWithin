using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCloseB : MonoBehaviour, IInteractable{
    public MeshRenderer Cam;
    public BoxCollider Button;
    public GameObject OpenButton;
    public GameObject DoorButton;
    public bool isOpenButton;
    public void Interact(){
        if (isOpenButton==false)
        {
            OpenButton.GetComponent<ButtonOpenB>().TurnOn();
            DoorButton.GetComponent<ButtonDoorB>().TurnOff();
            TurnOff();
        }else
        {
            OpenButton.GetComponent<ButtonOpenB>().TurnOn();
            TurnOff();
        }
    }
    public void TurnOn(){
        Cam.enabled=true;
        Button.enabled=true;
    }
    public void TurnOff(){
        Cam.enabled=false;
        Button.enabled=false;
    }
}