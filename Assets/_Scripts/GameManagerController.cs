using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerController : MonoBehaviour {
    public GameObject P1GoalObject, P2GoalObject, winPlayerObj;
    public Animator endingAnimationController;
    public float delayEndingTime;
    public bool gameFinished;
    private bool _executedOnce;

    private void Start()
    {
        winPlayerObj = null;
        _executedOnce = false;
    }
	// Update is called once per frame
	void Update () {
        if(winPlayerObj != null)
        {
            if(winPlayerObj.GetComponent<Rigidbody2D>().velocity.y == 0f)
            {
                if (gameFinished && _executedOnce == false)
                {
                    _executedOnce = true;
                    Invoke("playEnding", delayEndingTime);
                }
            }
            
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
    public void setWinPlayerObj(GameObject obj)
    {
        winPlayerObj = obj;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
