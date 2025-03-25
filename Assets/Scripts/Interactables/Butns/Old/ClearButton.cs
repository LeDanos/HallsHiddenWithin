using TMPro;
using UnityEngine;

public class ClearButton : MonoBehaviour, IInteractable{
    public TextMeshPro codeText;
    public GameObject confirmButton;
    public void Interact(){
        confirmButton.GetComponent<ConfirmButton>().codeC[0]=0;
        confirmButton.GetComponent<ConfirmButton>().codeC[1]=0;
        confirmButton.GetComponent<ConfirmButton>().codeC[2]=0;
        confirmButton.GetComponent<ConfirmButton>().codeC[3]=0;
        confirmButton.GetComponent<ConfirmButton>().changing=0;
        codeText.text="____";
    }
}