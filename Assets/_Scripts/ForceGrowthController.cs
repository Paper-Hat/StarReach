using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scales the transferrable force with how far the player went up/down
//resets magnitude after small delay when they hit the ground
public class ForceGrowthController : MonoBehaviour
{
    //Max height/depth that either player reaches, increases the transferrable force transmission
    public float maxHeightMagnitude;
    public Transform contactPoint;

    public float timeDelay;

    // Use this for initialization
    void Start ()
    {
        maxHeightMagnitude = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Mathf.Abs(contactPoint.position.y) > maxHeightMagnitude)
        {
            maxHeightMagnitude = Mathf.Abs(contactPoint.position.y);
        }
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(ResetMagnitude());
        }
    }
    
    //Resets magnitude after small delay
    public IEnumerator ResetMagnitude()
    {
        yield return new WaitForSeconds(timeDelay);
        maxHeightMagnitude = 0;
    }
}
