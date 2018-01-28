using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//Controls movement for left/right controls
public class TouchController : MonoBehaviour
{
    public static bool doubleTapped;
    //players according to their position in the coordinate system
    public Rigidbody2D topPlayer;
    public Rigidbody2D bottomPlayer;
    public float minHeightForMovement;
    public float touchFollowSpeed;
    //max distance allowed before the player moves in the direction of the touch
    public float maxDistance;

    //bools to allow either player to only be moving in direction at a time
    private bool _topAlreadyMoving;
    private bool _botAlreadyMoving;
    //checks for double tap
    private float _doubleTapTimer;
    private float _maxTimeGap = .2f;
    private int _tapCount;

	// Use this for initialization
	void Start ()
    {
        _topAlreadyMoving = false;
        _botAlreadyMoving = false;
        _doubleTapTimer = 0;
        _tapCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount < 2)
        {
            doubleTapped = false;
        }

        if (Input.touchCount >= 2)
        {
            doubleTapped = true;
            //Top Player
            if (Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < .5f &&
                Camera.main.ScreenToViewportPoint(Input.GetTouch(1).position).y < .5f)
            {
                topPlayer.gameObject.GetComponent<ForceTransferController>().CalculateForceTransfer();
            }

            //Bottom Player
            else if (Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y > .5f &&
                     Camera.main.ScreenToViewportPoint(Input.GetTouch(1).position).y > .5f)
            {
                bottomPlayer.gameObject.GetComponent<ForceTransferController>().CalculateForceTransfer();
            }

        }

        if (Mathf.Abs(topPlayer.transform.position.y) > minHeightForMovement || Mathf.Abs(bottomPlayer.transform.position.y) > minHeightForMovement)
        {
           
            if(Input.touchCount == 1)
            {
                //Top Player
                if (Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y < .5f && 
                    Mathf.Abs(topPlayer.transform.position.y) > minHeightForMovement)
                {

                    if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - bottomPlayer.transform.position.x) > maxDistance)
                    {

                        float direction = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - topPlayer.transform.position.x;
                        topPlayer.velocity = new Vector2(direction * touchFollowSpeed, topPlayer.velocity.y);
                    }

                    else
                        topPlayer.velocity = new Vector2(0, topPlayer.velocity.y);
                }

                //Bottom Player
                if (Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y > .5f &&
                    Mathf.Abs(bottomPlayer.transform.position.y) > minHeightForMovement)
                {
                    if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - bottomPlayer.transform.position.x) > maxDistance)
                    {

                        float direction = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - bottomPlayer.transform.position.x;
                        bottomPlayer.velocity = new Vector2(direction * touchFollowSpeed, bottomPlayer.velocity.y);
                    }

                    else
                        bottomPlayer.velocity = new Vector2(0, bottomPlayer.velocity.y);
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
