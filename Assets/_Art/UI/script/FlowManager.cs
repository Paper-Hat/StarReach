using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowManager : MonoBehaviour {

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
