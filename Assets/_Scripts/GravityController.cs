using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simulates gravity for the players
public class GravityController : MonoBehaviour
{
    //To be set to 1 or -1
    public int gravityDirection;
    //to be used for the force
    public float gravityStrength;
    public Rigidbody2D rigidB;
	
	// Update is called once per frame
	void FixedUpdate()
    {
        //apply gravity
        rigidB.AddForce(Vector2.up * gravityDirection * gravityStrength);
	}
}
