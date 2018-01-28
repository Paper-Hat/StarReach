using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private bool win, doneSlow, p1;
    private float oldGrav;
    public Rigidbody2D rBod;
    private GameObject player;
    public GameObject star;
    private Coroutine sco;
    private GravityController gctrl;

    Vector3 newStarPosition, offset;

    float wantedTime = 1;
    float currentTime = 0f;

    void Awake()
    {
        doneSlow = false;
        offset = new Vector3(0, .5f, 0);
        win = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        win = true;
        player = col.gameObject;
        if (player.transform.position.y > 0)
            p1 = true;
        gctrl = player.GetComponent<GravityController>();
        sco = StartCoroutine(SlowDown());

    }

    void FixedUpdate()
    {
        if (doneSlow)
        {
            if (currentTime <= wantedTime)
            {
                currentTime += Time.deltaTime;
                if (star.transform.position != newStarPosition)
                    star.transform.position = Vector3.Lerp(star.transform.position, newStarPosition, currentTime / wantedTime);
                gctrl.gravityStrength = oldGrav;
            }
        }
    }

    public IEnumerator SlowDown()
    {

        if (p1)
        {
            while (rBod.velocity.y >= 0)
            {
                rBod.velocity = new Vector2(rBod.velocity.x, rBod.velocity.y - .1f);
                yield return new WaitForSeconds(.1f);
            }
        }
        else
        {
            while (rBod.velocity.y >= 0)
            {
                rBod.velocity = new Vector2(rBod.velocity.x, rBod.velocity.y + .1f);
                yield return new WaitForSeconds(.1f);
            }
        }
        oldGrav = gctrl.gravityStrength;
        gctrl.gravityStrength = 0f;
        if (p1)
            newStarPosition = player.transform.position + offset;
        else
            newStarPosition = player.transform.position - offset;
        doneSlow = true;
        yield return new WaitForSeconds(1f);
        sco = null;
    }
}
