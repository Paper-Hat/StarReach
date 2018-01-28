using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager : MonoBehaviour {

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void Load(string str)
    {
        SceneManager.LoadScene(str);
    }
}
