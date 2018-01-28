using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObjectBehavior : MonoBehaviour {

    public GameObject goalObj;
    private Coroutine delayCoroutine;

    void OnCollisionEnter2D(Collision2D col)
    {
        delayCoroutine = StartCoroutine(CoDelay());
        goalObj.transform.SetParent(col.gameObject.transform);
    }
    IEnumerator CoDelay()
    {
        yield return new WaitForSeconds(1f);
        delayCoroutine = null;
    }
}
