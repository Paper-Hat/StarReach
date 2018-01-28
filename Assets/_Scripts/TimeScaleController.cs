using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public Transform topPlayer;
    public Transform bottomPlayer;
    public BoxCollider2D slowDownRange;
    public float minDropHeightForSloMo;
    public float slowSpeedBy;

    private bool hasSlowed;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (slowDownRange.OverlapPoint(topPlayer.position) &&
            slowDownRange.OverlapPoint(bottomPlayer.position) &&
            (topPlayer.gameObject.GetComponent<ForceGrowthController>().maxHeightMagnitude >= minDropHeightForSloMo ||
            bottomPlayer.gameObject.GetComponent<ForceGrowthController>().maxHeightMagnitude >= minDropHeightForSloMo) && 
            !hasSlowed)
        {
            topPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(topPlayer.GetComponent<Rigidbody2D>().velocity.x, topPlayer.GetComponent<Rigidbody2D>().velocity.y * slowSpeedBy);
            bottomPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(bottomPlayer.GetComponent<Rigidbody2D>().velocity.x, bottomPlayer.GetComponent<Rigidbody2D>().velocity.y * slowSpeedBy);
            hasSlowed = true;
            //Time.timeScale = slowScale;
        }

        else
        {
            hasSlowed = false;
           // Time.timeScale = 1;
        }
    }
}
