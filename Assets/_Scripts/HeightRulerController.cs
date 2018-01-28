using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightRulerController : MonoBehaviour {

    private Slider heightRuler;
    public Slider maxHeightSlider;
    public GameManagerController gameController;
    public Text highScoreText;
    public GameObject playerObject;
    public float height, minHeight, maxHeight, highestReached;
    // Initialize
	void Start () {
        heightRuler = GetComponent<Slider>();
        //Sets clamp for ruler to max and min values set in ruler - REMINDER TO CHANGE BASED ON ACTUAL MAP VALUES
        minHeight = heightRuler.minValue;
        maxHeight = gameController.getGoalHeight();
        heightRuler.maxValue = maxHeight;
        highestReached = 0f;
        maxHeightSlider.maxValue = maxHeight;
	}
	
    //Continually clamp player height to max and min values set in slider and current values on FixedUpdate
	void FixedUpdate () {
        height = Mathf.Clamp(Mathf.Abs(playerObject.transform.position.y), minHeight, maxHeight);
        UpdateHeightRuler();
        
        //heightRuler.value = height;
        maxHeightSlider.value = highestReached;
	}

    void UpdateHeightRuler()
    {
        heightRuler.value = height;
        if (height > highestReached)
        {
            highestReached = height;
            highScoreText.text = ((int)highestReached).ToString();
        }
            
    }
}
