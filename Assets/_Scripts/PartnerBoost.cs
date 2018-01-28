using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Attached to Booster game object - Activated by opposite player, causes an increase in
the next force transfer*/
public class PartnerBoost : MonoBehaviour {
    public float boost;
    public GameObject activeSystem, inactiveSystem;
    public TimerController timerController;
    private GameObject player, oppPlayer;
    private TimerController optc;
    public bool active;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            oppPlayer = player.GetComponent<TimerController>().otherPlayer;
            optc = oppPlayer.GetComponent<TimerController>();
            optc.goodTiming = true;
            optc.boostForce = boost;
            timerController.SetBooster(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            oppPlayer = player.GetComponent<TimerController>().otherPlayer;
            optc = oppPlayer.GetComponent<TimerController>();
            optc.goodTiming = false;
        }
    }
}
