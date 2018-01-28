using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Measures the distance between the player and the floor when the key/UI button is pressed
//The closer they are to the floor when pressed, more of the accumulated force of the other player will be used
public class ForceTransferController : MonoBehaviour
{
    //Manages sound effects
    public SFXManager sfx;
    //To hold reference to the strength of the sfx to be player
    //from 1 -> 3+  from trash to strong
    private int soundType;

    public static bool canTransfer;
    public enum TransmissionRating{Optimal, SubOptimal, Trash, Zero };
    public static TransmissionRating lastTransmissionRating;

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
    public bool isMoving;
    //Reference to the animation controller
    public Animator animatorController;

    //time to pause after impact before transmitting the force
    public float pauseTime;

    private Vector2 _addedForce;
    private static bool _transmitting;
    private bool _playerOneTapped;
    private bool _playerTwoTapped;
    private Rigidbody2D _rb2d;

    // Use this for initialization
    void Start()
    {
        soundType = 3;
        _addedForce = Vector2.zero;
        _rb2d = GetComponent<Rigidbody2D>();
        canTransfer = true;
        _transmitting = false;
        lastTransmissionRating = TransmissionRating.Zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !_playerOneTapped)
        {
            _playerOneTapped = true;
            CalculateForceTransfer();
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && !_playerTwoTapped)
        {
            _playerTwoTapped = true;
            CalculateForceTransfer();
        }

        if (this.name.Contains("Top"))
        {
            if (_rb2d.velocity.y < 0.01f && _rb2d.velocity.y > -0.01f)
            {
                animatorController.SetInteger("State", 3);
            }
            if (_rb2d.velocity.y > 0.01f)
            {
                animatorController.SetInteger("State", 1);
            }
            if (_rb2d.velocity.y < -0.01f)
            {
                animatorController.SetInteger("State", 2);
            }
        }
        else if (this.name.Contains("Bottom"))
        {
            if (_rb2d.velocity.y < 0.01f && _rb2d.velocity.y > -0.01f)
            {
                animatorController.SetInteger("State", 3);
            }
            if (_rb2d.velocity.y > 0.01f)
            {
                animatorController.SetInteger("State", 2);
            }
            if (_rb2d.velocity.y < -0.01f)
            {
                animatorController.SetInteger("State", 1);
            }
        }


    }

    //transfer force to the other player, 
    //amount of accumulated force transfered depends on how close falling player is to the ground on key/button press
    public void CalculateForceTransfer()
    {
        if (isMoving && canTransfer)
        {
            canTransfer = false;
            StartCoroutine(ResetTransfer());

            float transferPercentage = 0;

            if (Mathf.Abs(transform.position.y) < firstTransferHeight)
            {
                transferPercentage = firstTransferRatio;
                lastTransmissionRating = TransmissionRating.Optimal;
            }

            else if (Mathf.Abs(transform.position.y) < secondTransferHeight)
            {
                transferPercentage = secondTransferRatio;
                lastTransmissionRating = TransmissionRating.SubOptimal;
            }

            else if (Mathf.Abs(transform.position.y) < thirdTransferHeight)
            {
                transferPercentage = thirdTransferRatio;
                lastTransmissionRating = TransmissionRating.Trash;
            }

            else
            {
                transferPercentage = 0;
                lastTransmissionRating = TransmissionRating.Zero;
            }

            _addedForce =
                transferPercentage *
                Vector2.up *
                forceMultiplier *
                -otherPlayer.GetComponent<GravityController>().gravityDirection *
                GetComponent<ForceGrowthController>().maxHeightMagnitude;
        }
    }

    public IEnumerator ResetTransfer()
    {
        yield return new WaitForSeconds(1);
        canTransfer = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor") && !_transmitting)
        {
            _transmitting = true;
            StartCoroutine(TransmitForce());  
        }
    }

    public IEnumerator TransmitForce() 
    {
<<<<<<< HEAD
        VibrationManager.Vibrate(500);
        yield return new WaitForSeconds(pauseTime);
        VibrationManager.Cancel();
=======
        if(lastTransmissionRating == TransmissionRating.Trash)
        {
            soundType = 1;
            Debug.Log("Rating = 1");
        }
        else if(lastTransmissionRating == TransmissionRating.SubOptimal)
        {
            soundType = 2;
            Debug.Log("Rating = 2");
        }
        else if(lastTransmissionRating == TransmissionRating.Optimal)
        {
            soundType = 3;
            Debug.Log("Rating = 3");
        }

        //sfx on land
        sfx.PlayTransmission(soundType);

        yield return new WaitForSeconds(pauseTime);

        sfx.PlayReceive(soundType);
>>>>>>> 74f130d40925b298e50049b31b962ab670b84ce6

        otherPlayer.AddForce(
              defaultForce *
              Vector2.up *
              -otherPlayer.GetComponent<GravityController>().gravityDirection
              + _addedForce);

        isMoving = false;

        _addedForce = Vector2.zero;

        if (_playerOneTapped)
            _playerOneTapped = false;

        if (_playerTwoTapped)
            _playerTwoTapped = false;

        _transmitting = false;

        soundType = 3;
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isMoving = true;
        }
    }

}
