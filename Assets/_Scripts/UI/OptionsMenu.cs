using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //Holds name of the mainMenu
    public string mainMenu;

    //Holds ref to panel gameObjects
    //
    //
    //NOTE - startMenuPanel will only be used on the main start menu AND NOT in actual game
    public GameObject startMenuPanel;
    public GameObject optionsPanel;
    public GameObject pausePanel;

    //Holds ref to sliders
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider SFXSlider;

    //Holds ref to music audio sources
    public AudioSource[] music;
    //Holds ref to sfx audio sources
    public AudioSource[] SFX;

    //sets optionsPanel to false and startMenuPanel to true
    //Returns to main menu
    //
    //
    //NOTE - will be used on the main start menu NOT in game
    public void ReturnToStartMenu()
    {
        optionsPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    //Sets master volume equal to that of the value of the slider
    public void MasterVolumeControl()
    {
        AudioListener.volume = masterVolumeSlider.value;
    }

    //Sets all audioSources listed to the slider value of music
    public void MusicVolumeControl()
    {
        for(int i = 0; i < music.Length; i++)
        {
            music[i].volume = musicVolumeSlider.value;
        }
    }

    //Sets all audioSources listed to the slider value of sfx
    public void SFXControl()
    {
        for (int i = 0; i < SFX.Length; i++)
        {
            SFX[i].volume = SFXSlider.value;

            Debug.Log("Test" + i);
        }
    }
}
