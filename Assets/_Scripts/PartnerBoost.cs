using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Attached to Booster game object - Activated by opposite player, causes an increase in
the next force transfer*/
public class PartnerBoost : MonoBehaviour {
    public float boost;
    private GameObject player, oppPlayer;
    void OnTriggerStay2D(Collider2D other)
    {
        player = other.gameObject;
        oppPlayer = player.GetComponent<TimerController>().otherPlayer;
        oppPlayer.GetComponent<TimerController>().goodTiming = true;
        oppPlayer.GetComponent<TimerController>().boostForce = boost;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        player = other.gameObject;
        oppPlayer = player.GetComponent<TimerController>().otherPlayer;
        oppPlayer.GetComponent<TimerController>().goodTiming = false;
    }
}
