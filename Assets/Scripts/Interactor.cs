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
    public Transform InteractorSource;
    public float InteractRange = 2f;
    public TextMeshProUGUI InteractButtonUI;
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
                    if (hitInfo.collider.gameObject.tag=="Door")
                    {
                        hitInfo.collider.gameObject.GetComponent<DoorInteractable>().interactedByPlayer=true;
                    }
                    interactObj.Interact();
                }
            }
        }else
        {
            InteractButtonUI.enabled=false;
        }
    }
}
