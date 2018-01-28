using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementController : MonoBehaviour
{
    public Rigidbody2D topPlayer;
    public Rigidbody2D botPlayer;
    public float movementSpeed;
    public float minHeightForMovement;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Mathf.Abs(topPlayer.transform.position.y) > minHeightForMovement)
            MoveLeft(topPlayer);

        if (Input.GetKey(KeyCode.X) && Mathf.Abs(topPlayer.transform.position.y) > minHeightForMovement)
            MoveRight(topPlayer);

        if (Input.GetKey(KeyCode.N) && Mathf.Abs(botPlayer.transform.position.y) > minHeightForMovement)
            MoveLeft(botPlayer);

        if (Input.GetKey(KeyCode.M) && Mathf.Abs(botPlayer.transform.position.y) > minHeightForMovement)
            MoveRight(botPlayer);
    }

    public void MoveLeft(Rigidbody2D rigidB)
    {
        //flip directions depending on the player vertical sides
        rigidB.velocity = new Vector2(-movementSpeed, rigidB.velocity.y);

    }

    public void MoveRight(Rigidbody2D rigidB)
    {
        //flip directions depending on the player vertical sides     
        rigidB.velocity = new Vector2(movementSpeed, rigidB.velocity.y);
    }
}
