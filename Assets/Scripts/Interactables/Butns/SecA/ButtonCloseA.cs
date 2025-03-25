using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCloseA : MonoBehaviour, IInteractable{
    public MeshRenderer Cam;
    public BoxCollider Button;
    public GameObject OpenButton;
    public GameObject DoorButton;
    public void Interact(){
        OpenButton.GetComponent<ButtonOpenA>().TurnOn();
        DoorButton.GetComponent<ButtonDoorA>().TurnOff();
        TurnOff();
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