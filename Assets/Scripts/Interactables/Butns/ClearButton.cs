using TMPro;
using UnityEngine;

public class ClearButton : MonoBehaviour, IInteractable{
    public TextMeshPro codeText;
    public void Interact(){
        GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().code[0]=0;
        GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().code[1]=0;
        GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().code[2]=0;
        GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().code[3]=0;
        GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().changing=0;
        codeText.text="____";
    }
}