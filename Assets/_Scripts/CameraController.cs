using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Camera controller that follows the two player objects
/// </summary>
public class CameraController : MonoBehaviour {
    //Reference to player1 and player2
    public GameObject p1Object, p2Object;
    //Reference to the force controllers of the player objects
    private ForceTransferController _p1ForceController, _p2ForceController;

    public float camOffset;
    private float transferStartPosY, transferPosY;
    private float step;

    private bool resetStepP1, resetStepP2;

	// Use this for initialization
	void Start () {
        camOffset = 2;
        step = 0;

        resetStepP1 = false;
        resetStepP2 = false;

        _p1ForceController = p1Object.GetComponent<ForceTransferController>();
        _p2ForceController = p2Object.GetComponent<ForceTransferController>();
    }

    void FixedUpdate()
    {
        if (_p1ForceController.isMoving)
        {
            resetStepP2 = false;

            if(p1Object.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                transferPosY = p1Object.transform.position.y - camOffset;

                if(!resetStepP1)
                {
                    step = 0;

                    resetStepP1 = true;
                }
            }
            else
                transferPosY = p1Object.transform.position.y + camOffset;

            //Debug.Log("vel - " + p1Object.GetComponent<Rigidbody2D>().velocity);
            Camera.main.transform.position = new Vector3(p1Object.transform.position.x, Mathf.Lerp(GetComponent<Transform>().position.y, transferPosY, step), -10);

            step += .01f;
        }
        else if (_p2ForceController.isMoving)
        {
            resetStepP1 = false;

            if (p2Object.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                transferPosY = Mathf.Abs(p2Object.transform.position.y) - camOffset;

                if (!resetStepP2)
                {
                    step = 0;

                    resetStepP2 = true;
                }
            }
            else
                transferPosY = Mathf.Abs(p2Object.transform.position.y) + camOffset;

            //Debug.Log("vel - " + p2Object.GetComponent<Rigidbody2D>().velocity.y);
            //transferPosY = p2Object.transform.position.y - camOffset;

            Camera.main.transform.position = new Vector3(p2Object.transform.position.x, Mathf.Lerp(Mathf.Abs(GetComponent<Transform>().position.y), transferPosY, step) * -1, -10);//p2Object.transform.position.y - 2, -10);

            step += .01f;
        }
    }
}
