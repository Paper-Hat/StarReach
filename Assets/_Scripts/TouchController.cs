using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//Controls movement for left/right controls
public class TouchController : MonoBehaviour, IPointerClickHandler
{
    //players according to their position in the coordinate system
    public MovementController topPlayer;
    public MovementController bottomPlayer;

    //bools to allow either player to only be moving in direction at a time
    private bool _topAlreadyMoving;
    private bool _botAlreadyMoving;

	// Use this for initialization
	void Start ()
    {
        _topAlreadyMoving = false;
        _botAlreadyMoving = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                //Top player touch detection
                if (Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).y > 0)
                {
                    if (!_topAlreadyMoving)
                    {
                        if (Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).x > 0)
                            topPlayer.MoveRight();

                        else
                            topPlayer.MoveLeft();

                        _topAlreadyMoving = true;
                    }
                }

                //Bottom player touch detection
                else
                {
                    if (!_botAlreadyMoving)
                    {
                        if (Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).x > 0)
                            bottomPlayer.MoveRight();

                        else
                            bottomPlayer.MoveLeft();

                        _botAlreadyMoving = true;
                    }
                }
            }

            //reset movement booleans on touch ended
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                //top player released 
                if (Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).y > 0)
                    _topAlreadyMoving = false;

                //bottom player released
                else
                    _botAlreadyMoving = false;

            }
        }
    }
}
