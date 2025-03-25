using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonOpenB : MonoBehaviour, IInteractable{
    public MeshRenderer Desktop;
    public BoxCollider Button;
    public GameObject CloseButton;
    public GameObject DoorButton;
    public bool DoorOpen=false;
    public GameObject CloseButtonOpen;
    public void Interact(){
        if (DoorOpen==false)
        {
            CloseButton.GetComponent<ButtonCloseB>().TurnOn();
            DoorButton.GetComponent<ButtonDoorB>().TurnOn();
            TurnOff();
        }else
        {
            CloseButtonOpen.GetComponent<ButtonCloseB>().TurnOn();
            TurnOff();
        }
    }
    public void TurnOn(){
        Desktop.enabled=true;
        Button.enabled=true;
    }
    public void TurnOff(){
        Desktop.enabled=false;
        Button.enabled=false;
    }
}