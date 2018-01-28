using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool win, doneSlow, p1;
    private float oldGrav;
    public Rigidbody2D rBod;
    private GameObject player;
    public GameObject star;
    private Coroutine sco;
    private GravityController gctrl;
    public float stopYPos;
    Vector3 newStarPosition, offset;
    public SFXManager SoundEffects;

    float wantedTime = 1;
    float currentTime = 0f;
    public bool _starIsChild;
    void Awake()
    {
        stopYPos = 0;
        doneSlow = false;
        offset = new Vector3(0, .5f, 0);
        win = false;
        _starIsChild = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("triggered");

            win = true;
            player = col.gameObject;
            stopYPos = player.transform.position.y;
            if (player.transform.position.y > 0)
                p1 = true;
            gctrl = player.GetComponent<GravityController>();
            gctrl.gravityStrength = 0;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("TEST2");
            sco = StartCoroutine(SlowDown());
        }        

    }

    void FixedUpdate()
    {
        if(stopYPos != 0 && _starIsChild == false)
        {
            //Debug.Log("TEST");
            player.transform.position = new Vector3(player.transform.position.x, stopYPos, -1);
        }
            

        if (doneSlow)
        {
            if (currentTime <= wantedTime)
            {
                currentTime += Time.deltaTime;
                if (star.transform.position != newStarPosition)
                    star.transform.position = Vector3.Lerp(star.transform.position, newStarPosition, currentTime / wantedTime);

                SoundEffects.PlayStar();
                gctrl.gravityStrength = 10f;
            }
        }
    }

    public IEnumerator SlowDown()
    {
        if (p1)
        {
            while (rBod.velocity.y >= 0)
            {
                rBod.velocity = new Vector2(rBod.velocity.x, rBod.velocity.y - .5f);
                Debug.Log("p1 vel = " + rBod.velocity);
                Debug.Log(gctrl.gravityStrength);
                yield return null;//new WaitForSeconds(.1f);
            }
        }
        /*else
        {
            while (rBod.velocity.y >= 0)
            {
                rBod.velocity = new Vector2(rBod.velocity.x, rBod.velocity.y + .5f);
                Debug.Log("p2 vel = " + rBod.velocity);
                yield return null;//new WaitForSeconds(.1f);
            }
        }*/

        oldGrav = gctrl.gravityStrength;
        gctrl.gravityStrength = 0f;
        if (p1)
            newStarPosition = player.transform.position + offset;
        else
            newStarPosition = player.transform.position - offset;
        doneSlow = true;
        yield return new WaitForSeconds(1f);
        sco = null;
        Debug.Log("DEAD");
    }
    public void SetBoolStarIsChild()
    {
        _starIsChild = true;
    }
}
