using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lore : MonoBehaviour
{
    public bool done;
	// Use this for initialization
	void Start ()
    { 

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(done)
        {
            SceneManager.LoadScene("RubenTestScene1");
            print("done");
        }
	}
}
