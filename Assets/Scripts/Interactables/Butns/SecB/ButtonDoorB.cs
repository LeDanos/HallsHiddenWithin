using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonDoorB : MonoBehaviour, IInteractable{
    public BoxCollider Button;
    public GameObject Door;
    public GameObject OpenButton;
    public GameObject CloseButton;
    public GameObject CloseButtonOpen;
    public void Interact(){
        Door.transform.position=new Vector3(Door.transform.position.x,Door.transform.position.y+4,Door.transform.position.z);
        OpenButton.GetComponent<ButtonOpenB>().TurnOff();
        CloseButton.GetComponent<ButtonCloseB>().TurnOff();
        Button.enabled=false;
        OpenButton.GetComponent<ButtonOpenB>().DoorOpen=true;
        CloseButtonOpen.GetComponent<ButtonCloseB>().TurnOn();
    }
    public void TurnOn(){
        Button.enabled=true;
    }
    public void TurnOff(){
        Button.enabled=false;
    }
}