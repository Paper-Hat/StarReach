using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Holds name of main menu scene
    public string mainMenu;

    //Holds ref to panel gameObjects
    public GameObject pausePanel;
    public GameObject optionsPanel;

    //Holds ref to sliders
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider SFXSlider;

    //Holds ref to music audio sources
    public AudioSource[] music;
    //Holds ref to sfx audio sources
    public AudioSource[] SFX;

    private float gameTime;

    private void Awake()
    {
        gameTime = Time.timeScale;
    }

    //sets optionsPanel to false and startMenuPanel to true
    //Returns to main menu
    public void Pause()
    {
        //Pauses game
        Time.timeScale = 0;

        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    //Restarts gametime closes panels
    public void Unpause()
    {
        Time.timeScale = gameTime;

        optionsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    //Opens options, closes pause
    public void Options()
    {
        optionsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    //Changes scene from game to main menu
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene(mainMenu, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
