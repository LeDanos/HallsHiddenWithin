using TMPro;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable{
    public TextMeshPro codeText;
    public GameObject confirmButton;
    public int buttonNum;
    private int wait=0;
    public void Interact(){
        if (confirmButton.GetComponent<ConfirmButton>().changing<4&&wait==0)
        { 
            wait=10;
            confirmButton.GetComponent<ConfirmButton>().codeC[confirmButton.GetComponent<ConfirmButton>().changing]=buttonNum;
            confirmButton.GetComponent<ConfirmButton>().changing++;
            string s = string.Join("", confirmButton.GetComponent<ConfirmButton>().codeC);
            Debug.Log(s);
            codeText.text=s;
        }
    }
    void FixedUpdate()
    {
        if (wait>0)
        {
            wait--;
        }
    }
}