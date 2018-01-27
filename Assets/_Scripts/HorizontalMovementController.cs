using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls movement for left/right controls
public class HorizontalMovementController : MonoBehaviour
{
    public Rigidbody2D rigidB;
    public float movementSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MoveLeft()
    {
        rigidB.velocity = new Vector2(-movementSpeed, rigidB.velocity.y);
    }

    public void MoveRight()
    {
        rigidB.velocity = new Vector2(movementSpeed, rigidB.velocity.y);
    }
}
