using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rigidB;
    public float movementSpeed;

    public void MoveLeft()
    {
        //flip directions depending on the player vertical sides
        if (transform.position.y < 0)
            rigidB.velocity = new Vector2(-movementSpeed, rigidB.velocity.y);

        else
            rigidB.velocity = new Vector2(movementSpeed, rigidB.velocity.y);
    }

    public void MoveRight()
    {
        //flip directions depending on the player vertical sides
        if (transform.position.y < 0)
            rigidB.velocity = new Vector2(movementSpeed, rigidB.velocity.y);

        else
            rigidB.velocity = new Vector2(-movementSpeed, rigidB.velocity.y);
    }
}
