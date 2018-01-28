using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public Text timerText1;
    public Text timerText2;

    private float _timer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        _timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(_timer / 60F);
        int seconds = Mathf.FloorToInt(_timer - minutes * 60);
        string time = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText1.text = time;
        timerText2.text = time;
    }
}
