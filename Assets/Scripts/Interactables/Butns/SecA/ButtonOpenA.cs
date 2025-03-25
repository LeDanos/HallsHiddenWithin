using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonOpenA : MonoBehaviour, IInteractable{
    public MeshRenderer Desktop;
    public BoxCollider Button;
    public GameObject CloseButton;
    public GameObject DoorButton;
    public void Interact(){
        CloseButton.GetComponent<ButtonCloseA>().TurnOn();
        DoorButton.GetComponent<ButtonDoorA>().TurnOn();
        TurnOff();
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