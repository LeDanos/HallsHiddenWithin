using UnityEngine;

public class TimothyDamage : MonoBehaviour
{
    public GameObject Timothy;
    public GameObject TimothyAnimation;
    public AudioSource Bonk;
    public AudioSource Laugh;
    public void EventHit()
    {
        Debug.Log("GET TIMOTHIED");
        Bonk.enabled=true;
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().damaged==false)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().Damage();
        }else
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().Damage();
            EventEnd();
        }
    }
    public void EventStart()
    {
        Bonk.enabled=false;
        Laugh.transform.position=GameObject.Find("Player").transform.position;
        Laugh.enabled=false;
        if (GameObject.Find("Player").GetComponent<LoadManager>().zone==2)
        {
            TimothyAnimation.GetComponent<UnityEngine.UI.Image>().color=Color.red;
        }else
        {
            TimothyAnimation.GetComponent<UnityEngine.UI.Image>().color=Color.yellow;
        }
        TimothyAnimation.SetActive(true);
    }
    public void EventEnd()
    {
        Laugh.enabled=true;
        TimothyAnimation.SetActive(false);
        Timothy.GetComponent<TimothyController>().active=false;
        Timothy.GetComponent<TimothyController>().cooldown=1000;
        Timothy.GetComponent<TimothyController>().Breathing.transform.position=Timothy.GetComponent<TimothyController>().BreathingPoint;
    }
}
