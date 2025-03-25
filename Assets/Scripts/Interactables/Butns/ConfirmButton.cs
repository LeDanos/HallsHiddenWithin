using TMPro;
using UnityEngine;

public class ConfirmButton : MonoBehaviour, IInteractable{
    public Transform Door;
    private bool done=false;
    public int[] codeC={0,0,0,0};
    public int[] code={0,0,0,0};
    public int changing=0;
    public TextMeshPro[] codeText;
    public void Start(){
        Generate();
    }
    public void Interact(){
        if (done==false)
        {
            if (code[0]==codeC[0]&&code[1]==codeC[1]&&code[2]==codeC[2]&&code[3]==codeC[3])
            {
                done=true;
                Door.position= new Vector3(Door.position.x,Door.position.y+4,Door.position.z);
            }
        }
    }
    public void Generate(){
            code[0]=Random.Range(0,9);
            code[1]=Random.Range(0,9);
            code[2]=Random.Range(0,9);
            code[3]=Random.Range(0,9);
            codeText[0].text="1. = "+code[0].ToString();
            codeText[1].text="2. = "+code[1].ToString();
            codeText[2].text="3. = "+code[2].ToString();
            codeText[3].text="4. = "+code[3].ToString();
    }
    public void Restart(){
        if (done==true)
        {
            Door.position= new Vector3(Door.position.x,Door.position.y-6,Door.position.z);
            done=false;
        }
        codeC[0]=0;
        codeC[1]=0;
        codeC[2]=0;
        codeC[3]=0;
        Generate();
    }
}