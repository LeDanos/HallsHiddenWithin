using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    public GameObject[] cat;
    public bool super;
    public GameObject water;
    private void OnTriggerStay(Collider collision)
    {
        if (super == true)
        {
            if (water.GetComponent<ElecWater>().activated==false)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    foreach (var item in cat)
                    {
                        item.GetComponent<CatController>().Activate();
                    }
                }
            }
        }else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                foreach (var item in cat)
                {
                    item.GetComponent<CatController>().Activate();
                }
            }
        }
    }
}
