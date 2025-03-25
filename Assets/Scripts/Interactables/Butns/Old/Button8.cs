using TMPro;
using UnityEngine;

public class Button8 : MonoBehaviour, IInteractable{
    public TextMeshPro codeText;
    public void Interact(){
        if (GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().changing<4)
        { 
            GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().codeC[GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().changing]=8;
            string s = string.Join("", GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().codeC);
            GameObject.Find("Confirm Button").GetComponent<ConfirmButton>().changing++;
            codeText.text=s;
        }
    }
}