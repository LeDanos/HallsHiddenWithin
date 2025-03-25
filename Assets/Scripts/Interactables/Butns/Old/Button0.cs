using TMPro;
using UnityEngine;

public class Button0 : MonoBehaviour, IInteractable{
    public TextMeshPro codeText;
    public GameObject confirmButton;
    public int buttonNum;
    public void Interact(){
        if (confirmButton.GetComponent<ConfirmButton>().changing<4)
        { 
            confirmButton.GetComponent<ConfirmButton>().codeC[confirmButton.GetComponent<ConfirmButton>().changing]=buttonNum;
            string s = string.Join("", confirmButton.GetComponent<ConfirmButton>().codeC);
            confirmButton.GetComponent<ConfirmButton>().changing++;
            codeText.text=s;
        }
    }
}