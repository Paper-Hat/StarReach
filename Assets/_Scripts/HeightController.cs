using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour {

    public GameObject player;
    public HeightRulerController hrc;

	private void Awake () {
        //Begin tracking player height (two instances of script, one to track each player)
        hrc.height = Mathf.Abs(player.transform.localPosition.y);
	}
	void FixedUpdate () {
        //Continually track player height on FixedUpdate
        hrc.height= Mathf.Abs(player.transform.localPosition.y);
    }
}
