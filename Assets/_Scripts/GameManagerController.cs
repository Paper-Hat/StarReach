using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {
    public GameObject P1GoalObject, P2GoalObject;
    public Animator endingAnimationController;
    public float delayEndingTime;
    public bool gameFinished;
    private bool _executedOnce;

    private void Start()
    {
        _executedOnce = false;
    }
	// Update is called once per frame
	void Update () {
		if(gameFinished && _executedOnce == false)
        {
            _executedOnce = true;
            Invoke("playEnding", delayEndingTime);
        }
	}

    public float getGoalHeight()
    {
        return P1GoalObject.transform.position.y;
    }

    private void playEnding()
    {
        endingAnimationController.SetBool("isShowingEnding", true);
    }
}
