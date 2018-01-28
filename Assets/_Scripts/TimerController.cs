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
    public GameObject[] boosters;
    private GameObject theBooster;
    private ForceTransferController forceController;
	void Start () {
        goodTiming = false;
        otherForce = otherPlayer.GetComponent<ForceGrowthController>();
        forceController = GetComponent<ForceTransferController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) && delayCoroutine == null)
        {
            if (goodTiming)
            {
                DeactivateActiveBooster();
                ApplyForce();
            }
                
            delayCoroutine = StartCoroutine(CoDelay());
        }
        if(forceController.isMoving)
        {
            ActivateAllBoosters();
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

    public void DeactivateActiveBooster()
    {
        foreach(GameObject obj in boosters)
        {
            if(obj == theBooster)
            {
                obj.GetComponent<PartnerBoost>().activeSystem.SetActive(false);
                obj.GetComponent<PartnerBoost>().inactiveSystem.SetActive(true);
            }
        }
    }
    public void DeactivateInActiveBooster()
    {
        foreach (GameObject obj in boosters)
        {
            if (obj == theBooster)
            {
                obj.GetComponent<PartnerBoost>().activeSystem.SetActive(true);
                obj.GetComponent<PartnerBoost>().inactiveSystem.SetActive(false);
            }
        }
    }
    public void SetBooster(GameObject booster)
    {
        theBooster = booster;
    }
    private void ActivateAllBoosters()
    {
        foreach(GameObject obj in boosters)
        {
            obj.SetActive(true);
        }
    }
}
