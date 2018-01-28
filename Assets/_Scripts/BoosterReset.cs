using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterReset : MonoBehaviour
{
    // Use this for initialization
    public GameObject[] boosters;
    void ResetBoosters()
    {
        foreach (GameObject booster in boosters)
        {
            booster.GetComponent<PartnerBoost>().active = true;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
