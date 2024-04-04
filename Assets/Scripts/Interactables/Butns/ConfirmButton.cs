using TMPro;
using UnityEngine;

public class ConfirmButton : MonoBehaviour, IInteractable{
    public Transform Door;
    private bool done=false;
    public int[] codeC={0,0,0,0};
    public int[,] code={{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
    public int correctCode=0;
    public int changing=0;
    public TextMeshPro[] codeText;
    public void Start(){
        correctCode=Random.Range(0,5);
        for (int e = 6 - 1; e >= 0 ; e--)
        {
            code[e,0]=Random.Range(0,9);
            code[e,1]=Random.Range(0,9);
            code[e,2]=Random.Range(0,9);
            code[e,3]=Random.Range(0,9);
            string s = string.Join("", code[e,0],code[e,1],code[e,2],code[e,3]);
            codeText[e].text=s;
        }
    }
    public void Interact(){
        if (done==false)
        {
            if (code[correctCode,0]==codeC[0]&&code[correctCode,1]==codeC[1]&&code[correctCode,2]==codeC[2]&&code[correctCode,3]==codeC[3])
            {
                done=true;
                Door.position= new Vector3(Door.position.x,Door.position.y+6,Door.position.z);
            }
        }
    }
}