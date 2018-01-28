using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObjectBehavior : MonoBehaviour {

    public GameObject goalObj,playerObj;
    public ParticleSystem pSystem;
    public WinCondition winConditionObject;
    private Coroutine delayCoroutine;
    private bool _isChild;
    public bool _isp1;
     void Update()
    {
        if(_isChild)
        {
            if(_isp1)
                transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y+0.75f, playerObj.transform.position.z);
            else
                transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y-0.75f, playerObj.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            if (col.gameObject.name.Contains("Top"))
                _isp1 = true;
            else
                _isp1 = false;
            delayCoroutine = StartCoroutine(CoDelay());
            goalObj.transform.SetParent(col.gameObject.transform);
            pSystem.Play();
            winConditionObject.SetBoolStarIsChild();
            _isChild = true;
        }
       
    }
    IEnumerator CoDelay()
    {
        yield return new WaitForSeconds(1f);
        delayCoroutine = null;
    }
}
