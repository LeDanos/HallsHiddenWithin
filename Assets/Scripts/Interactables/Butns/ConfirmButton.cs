using TMPro;
using UnityEngine;

public class ConfirmButton : MonoBehaviour, IInteractable{
    public Transform Door;
    private bool done=false;
    public float[] codeC={0,0,0,0};
    public float[] code={0,0,0,0};
    public int changing=0;
    public TextMeshPro codeCText;
    public void Start(){
        codeC[0]=Random.Range(0,9);
        codeC[1]=Random.Range(0,9);
        codeC[2]=Random.Range(0,9);
        codeC[3]=Random.Range(0,9);
        string s = string.Join("", codeC);
        codeCText.text=s;
    }
    public void Interact(){
        if (done==false)
        {
            if (code[0]==codeC[0]&&code[1]==codeC[1]&&code[2]==codeC[2]&&code[3]==codeC[3])
            {
                done=true;
                Door.position= new Vector3(Door.position.x,Door.position.y+6,Door.position.z);
            }
        }
    }
}