using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {
    public GameObject creditsCanvas, regularCanvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateCredits()
    {
        creditsCanvas.SetActive(true);
        regularCanvas.SetActive(false);
    }
}
