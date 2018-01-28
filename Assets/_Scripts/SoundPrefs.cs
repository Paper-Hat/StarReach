using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundPrefs : MonoBehaviour {
    public AudioSource mainMenuAudioSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MasterVolume(Slider slider)
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("Master", slider.value);
    }
    public void SFXVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("SFX", slider.value);
    }
    public void MusicVolume(Slider slider)
    {
        mainMenuAudioSource.volume = slider.value;
        PlayerPrefs.SetFloat("Music", slider.value);
    }
}
