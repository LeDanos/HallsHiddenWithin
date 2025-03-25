using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecWaterDamage : MonoBehaviour
{
    public GameObject water;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && water.GetComponent<ElecWater>().electricity.enabled==true && water.GetComponent<ElecWater>().cooldown==0)
        {
            water.GetComponent<ElecWater>().cooldown=100;
            GameObject.Find("Player").GetComponent<PlayerMovement>().Damage();
        }
    }
}
