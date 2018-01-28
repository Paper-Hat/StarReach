using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public GameObject p1Object, p2Object;
    private ForceTransferController _p1ForceCont, _p2ForceCont;
	// Use this for initialization
	void Start () {
        _p1ForceCont = p1Object.GetComponent<ForceTransferController>();
        _p2ForceCont = p2Object.GetComponent<ForceTransferController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(_p1ForceCont.isMoving)
        {
            transform.position = new Vector3(p1Object.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(p2Object.transform.position.x, transform.position.y, transform.position.z);
        }
	}
}
