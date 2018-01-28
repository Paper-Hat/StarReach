using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMovementController : MonoBehaviour
{
    public Rigidbody2D rigidB;
    public float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        rigidB.velocity = new Vector2(movementSpeed, 0);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Border"))
        {
            movementSpeed *= -1;
            rigidB.velocity = new Vector2(movementSpeed, 0);
        }
    }
}
