using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Attached to Booster game object - Activated by opposite player, causes an increase in
the next force transfer*/
public class PartnerBoost : MonoBehaviour {
    public float boost;
    void OnTriggerStay2D(Collider2D other)
    {
        other.transform.parent.gameObject.GetComponent<TimerController>().goodTiming = true;
        other.transform.parent.gameObject.GetComponent<TimerController>().boostForce = boost;
    }
    void OnTriggerExit2D(Collider2D other)  {   other.transform.parent.gameObject.GetComponent<TimerController>().goodTiming = false;   }
}
