using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    public bool p1Turn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player1.GetComponent<ForceTransferController>().isMoving)
        {
            player1.GetComponent<ForceTransferController>().enabled = true;
            player1.GetComponent<TimerController>().enabled = false;
            player2.GetComponent<ForceTransferController>().enabled = false;
            player2.GetComponent<TimerController>().enabled = true;
        }
        else
        {
            player1.GetComponent<ForceTransferController>().enabled =false;
            player1.GetComponent<TimerController>().enabled = true;
            player2.GetComponent<ForceTransferController>().enabled = true;
            player2.GetComponent<TimerController>().enabled = false;
        }
	}
}
