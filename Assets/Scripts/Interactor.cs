using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform InteractorSource;
    public float InteractRange = 2f;
    public TextMeshProUGUI InteractButtonUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)&&GameObject.Find("Player").GetComponent<Pause>().isPaused==false)
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                InteractButtonUI.enabled=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                
                    interactObj.Interact();
                }
            }
        }else
        {
            InteractButtonUI.enabled=false;
        }
    }
}
