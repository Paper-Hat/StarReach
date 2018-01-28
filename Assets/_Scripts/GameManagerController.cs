using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {
    public GameObject P1GoalObject, P2GoalObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getGoalHeight()
    {
        return P1GoalObject.transform.position.y;
    }
}
