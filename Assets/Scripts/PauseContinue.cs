using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseContinue : MonoBehaviour, IPointerClickHandler
{
    public Canvas PausedOverlay;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        GameObject.Find("Player").GetComponent<Pause>().isPaused=false;
        PausedOverlay.enabled=false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Unpaused");
        Time.timeScale=1;
    }
}
