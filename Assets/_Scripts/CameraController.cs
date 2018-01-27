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
	// Use this for initialization
	void Start () {
        _p1ForceController = p1Object.GetComponent<ForceTransferController>();
        _p2ForceController = p2Object.GetComponent<ForceTransferController>();
    }

    void FixedUpdate()
    {
        if (_p1ForceController.isMoving)
        {
            Camera.main.transform.position = new Vector3(p1Object.transform.position.x, p1Object.transform.position.y, -10);
        }
        else if (_p2ForceController.isMoving)
        {
            Camera.main.transform.position = new Vector3(p2Object.transform.position.x, p2Object.transform.position.y, -10);
        }
    }
}
