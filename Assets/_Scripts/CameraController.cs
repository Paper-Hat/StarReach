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

    //Value forl offset of the camera
    public float camOffset;

    private float transferStartPosY, transferPosY;

    //time for camera movement
    private float step;
    public float stepGain;

    //Standard origin point for the camera
    public Vector3 camOriginPoint;

    private bool resetStepP1, resetStepP2;

	// Use this for initialization
	void Start () {
        camOffset = 1;
        step = 0;
        stepGain = .001f;

        camOriginPoint = new Vector3(0, 0, -10);

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

            //If p1 is falling towards the center make camera change offset to show that
            if(p1Object.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                transferPosY = p1Object.transform.position.y - camOffset;
                step += stepGain;
                //reset timestep when fall begins
                if (!resetStepP1)
                {
                    step = 0;

                    resetStepP1 = true;
                }
            }
            else
                transferPosY = p1Object.transform.position.y + camOffset;

            //number to the right is the bounding number before the camera starts to follow the player
            if(p1Object.GetComponent<ForceGrowthController>().contactPoint.position.y < 2)
            {
                transferPosY = camOriginPoint.y;
                step += stepGain;
            }
            
            Camera.main.transform.position = new Vector3(camOriginPoint.x, Mathf.Lerp(GetComponent<Transform>().position.y, transferPosY, step), -10);
           
        }
        else if (_p2ForceController.isMoving)
        {
            resetStepP1 = false;

            //if p2 is falling towards the center change canera offset to show that
            if (p2Object.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                transferPosY = Mathf.Abs(p2Object.transform.position.y) - camOffset;
                step += stepGain;
                if (!resetStepP2)
                {
                    step = 0;

                    resetStepP2 = true;
                }
            }
            else
                transferPosY = Mathf.Abs(p2Object.transform.position.y) + camOffset;

            //number to the right is the bounding number before the camera starts to follow the player
            if (p2Object.GetComponent<ForceGrowthController>().contactPoint.position.y > -2)
            {
                transferPosY = camOriginPoint.y;
                step += stepGain;
            }

            //Debug.Log("vel - " + p2Object.GetComponent<Rigidbody2D>().velocity.y);
            //transferPosY = p2Object.transform.position.y - camOffset;

            Camera.main.transform.position = new Vector3(camOriginPoint.x, Mathf.Lerp(Mathf.Abs(GetComponent<Transform>().position.y), transferPosY, step) * -1, -10);//p2Object.transform.position.y - 2, -10);

            //step += stepGain;
        }
    }
}
