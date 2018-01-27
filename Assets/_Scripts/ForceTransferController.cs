using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Measures the distance between the player and the floor when the key/UI button is pressed
//The closer they are to the floor when pressed, more of the accumulated force of the other player will be used
public class ForceTransferController : MonoBehaviour
{
    //The other player to transfer force to 
    public Rigidbody2D otherPlayer;
    //used to scale the the force applied
    public float forceMultiplier;

    //Percentage of additional force will be applied if within these transform heights
    public float firstTransferHeight;
    public float firstTransferRatio;

    public float secondTransferHeight;
    public float secondTransferRatio;

    public float thirdTransferHeight;
    public float thirdTransferRatio;

    //added default force for intial bounce;
    public float defaultForce;

    private Vector2 _addedForce;
    private bool _canAddMoreForce;

	// Use this for initialization
	void Start ()
    {
        _addedForce = Vector2.zero;
        _canAddMoreForce = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateForceTransfer();
        }

    }

    //transfer force to the other player, 
    //amount of accumulated force transfered depends on how close falling player is to the ground on key/button press
    public void CalculateForceTransfer()
    {

        float transferPercentage = 0;

        if (Mathf.Abs(transform.position.y) < firstTransferHeight)
            transferPercentage = firstTransferRatio;

        else if (Mathf.Abs(transform.position.y) < secondTransferHeight)
            transferPercentage = secondTransferRatio;

        else if (Mathf.Abs(transform.position.y) < thirdTransferHeight)
            transferPercentage = thirdTransferRatio;


        _addedForce =
            transferPercentage *
            Vector2.up *
            forceMultiplier *
            -otherPlayer.GetComponent<GravityController>().gravityDirection *
            GetComponent<ForceGrowthController>().maxHeightMagnitude;
        

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            otherPlayer.AddForce(
                defaultForce * 
                Vector2.up *
                -otherPlayer.GetComponent<GravityController>().gravityDirection
                + _addedForce);

            print("Transfered: " + (defaultForce *
                Vector2.up *
                -otherPlayer.GetComponent<GravityController>().gravityDirection
                + _addedForce));

            _addedForce = Vector2.zero;

        }
    }

}
