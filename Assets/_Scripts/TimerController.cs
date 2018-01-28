using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Grounded player's Timer button has this functionality
//When Airborne player passes over booster, grounded player can hit their timer for the airborne player to transfer a greater force to grounded player on the rebound
public class TimerController : MonoBehaviour {
    
    
    public bool goodTiming, press;
    public ForceGrowthController otherForce;
    public GameObject otherPlayer;
    private Coroutine delayCoroutine;
    public float boostForce;

	void Start () {
        goodTiming = false;
        otherForce = otherPlayer.GetComponent<ForceGrowthController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) && delayCoroutine == null)
        {
            if (goodTiming)
                ApplyForce();
            delayCoroutine = StartCoroutine(CoDelay());
        }
	}
    public void ApplyForce()
    {
        otherForce.maxHeightMagnitude += boostForce;
    }
    IEnumerator CoDelay()
    {
        yield return new WaitForSeconds(1f);
        delayCoroutine = null;
    }
}
