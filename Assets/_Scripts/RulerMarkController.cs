using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulerMarkController : MonoBehaviour {

    private Slider maxSlider;
    public HeightRulerController hrc;
	// Use this for initialization
	void Start () {
        maxSlider = GetComponent<Slider>();
        maxSlider.minValue = hrc.minHeight;
        maxSlider.maxValue = hrc.maxHeight;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateMaxSlider();
	}
    void UpdateMaxSlider() { maxSlider.value = hrc.highestReached; }
}
