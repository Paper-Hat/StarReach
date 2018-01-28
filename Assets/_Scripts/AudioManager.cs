using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public GameObject p1Object, p2Object, goalItemObject;
    public AudioSource pianoMusicAudioSource, fluteMusicAudioSource, clarinetMusicAudioSource,layer1MusicAudioSource, layer2MusicAudioSource;
    public float distanceDivider, layer1Divider, layer2Divider;
    private Rigidbody2D _p1rb2d, _p2rb2d;
    private ForceTransferController _p1ForceController, _p2ForceController;
    private float _step,_layerStep;
    private bool _isLerping,_isLayerLerping;
    private float _deltaStep;
    // Use this for initialization
    void Start () {
        _p1rb2d = p1Object.GetComponent<Rigidbody2D>();
        _p2rb2d = p2Object.GetComponent<Rigidbody2D>();
        _p1ForceController = p1Object.GetComponent<ForceTransferController>();
        _p2ForceController = p2Object.GetComponent<ForceTransferController>();
        pianoMusicAudioSource.volume = 0.5f;
        fluteMusicAudioSource.volume = 0.5f;
        clarinetMusicAudioSource.volume = 0.5f;
        layer1MusicAudioSource.volume = 0;
        layer2MusicAudioSource.volume = 0;
        _isLerping = false;
        Debug.Log("Threshold: " + goalItemObject.transform.position.y / distanceDivider);
        Debug.Log("Layer1: " + goalItemObject.transform.position.y / layer1Divider);
        Debug.Log("Layer2: " + goalItemObject.transform.position.y / layer2Divider);
    }
	
	void FixedUpdate () {
        //Debug.Log(Time.fixedDeltaTime);
        if (_p1ForceController.isMoving)
        {
            //If player one's distance is higher than the threshold
            if(p1Object.transform.position.y > goalItemObject.transform.position.y/distanceDivider)
            {
                _isLerping = true;
                LerpAudioSources(fluteMusicAudioSource, clarinetMusicAudioSource, 1.0f, 0.25f);
                //fluteMusicAudioSource.volume = 1.0f;
                //clarinetMusicAudioSource.volume = 0.25f;
            }

            if(p1Object.transform.position.y > goalItemObject.transform.position.y / layer1Divider)
            {
                _isLayerLerping = true;
                LerpAudioSourceSingular(layer1MusicAudioSource, 1.0f);
            }
            if(p1Object.transform.position.y > goalItemObject.transform.position.y / layer2Divider)
            {
                _isLayerLerping = true;
                LerpAudioSourceSingular(layer2MusicAudioSource, 1.0f);
            }
        }
        else
        {
            //If player one's distance is higher than the threshold
            if (Mathf.Abs(p2Object.transform.position.y) > goalItemObject.transform.position.y / distanceDivider)
            {
                //Change audio volume, brother is clarinet
                _isLerping = true;
                LerpAudioSources(fluteMusicAudioSource, clarinetMusicAudioSource, 0.25f, 1f);
                //fluteMusicAudioSource.volume = 0.25f;
                //clarinetMusicAudioSource.volume = 1f;
            }

            if (Mathf.Abs(p2Object.transform.position.y) > goalItemObject.transform.position.y / layer1Divider)
            {
                _isLayerLerping = true;
                LerpAudioSourceSingular(layer1MusicAudioSource, 1.0f);
            }
            if (Mathf.Abs(p2Object.transform.position.y) > goalItemObject.transform.position.y / layer2Divider)
            {
                _isLayerLerping = true;
                LerpAudioSourceSingular(layer2MusicAudioSource, 1.0f);
            }
        }
	}

    private void LerpAudioSources(AudioSource source1, AudioSource source2, float targetVolume1, float targetVolume2)
    {
        _step = 0;
        if (_isLerping)
        {            
            _step += Time.fixedDeltaTime;
            source1.volume = Mathf.Lerp(source1.volume, targetVolume1, _step);
            source2.volume = Mathf.Lerp(source2.volume, targetVolume2, _step);
            if (source1.volume == targetVolume1)
            {
                _isLerping = false;
            }
        }
    }

    private void LerpAudioSourceSingular(AudioSource source, float targetVolume)
    {
        _layerStep = 0;
        if (_isLayerLerping)
        {
            _layerStep += Time.fixedDeltaTime;
            source.volume = Mathf.Lerp(source.volume, targetVolume, _layerStep);
            if (source.volume == targetVolume)
            {
                _isLayerLerping = false;
            }
        }
    }
}
