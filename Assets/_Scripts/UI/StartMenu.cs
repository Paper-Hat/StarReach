using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuPanel;
    public GameObject OptionsPanel;

    //Loads scene from string in arg
    public void PlayButton(string scene)
    {
        SceneManager.LoadScene(scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    //Sets Start menu panel to non active and activates options panel
    //Goes to option menu
    public void OptionsButton()
    {
        StartMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    //Closes app
    public void QuitButton()
    {
        Application.Quit();
    }
}
