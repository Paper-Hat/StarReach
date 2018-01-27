using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightRulerController : MonoBehaviour {

    private Slider heightRuler;
    public float height, minHeight, maxHeight, highestReached;
    // Initialize
	void Start () {
        heightRuler = GetComponent<Slider>();
        //Sets clamp for ruler to max and min values set in ruler - REMINDER TO CHANGE BASED ON ACTUAL MAP VALUES
        minHeight = heightRuler.minValue;
        maxHeight = heightRuler.maxValue;
        highestReached = 0f;
	}
	
    //Continually clamp player height to max and min values set in slider and current values on FixedUpdate
	void FixedUpdate () {
        UpdateHeightRuler();
        height = Mathf.Clamp(height, minHeight, maxHeight);
	}

    void UpdateHeightRuler() {
        heightRuler.value = height;
        if (height > highestReached)
            highestReached = height;
    }
}
