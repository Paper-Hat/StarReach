using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource hardReceive, hardTransmission, receiveFail;
    public AudioManager audioManager;

    void Start()
    {
        hardReceive.volume = .5f;
        hardTransmission.volume = .5f;
        receiveFail.volume = .7f;
    }

    //Receive will have a height variable and quality
    //level                            quality
    //1 - from small height           1 - will cause fail sound, no matter the height
    //2 - from med height             2 - ok
    //3 - from large height           3 - well timed 
    public void PlayReceive(int q)
    {
        Debug.Log("transmission, zone 2 >temp< in sfxmanager");
        //if(level == 1 || level == 2)
        if (audioManager.p1Object.transform.position.y < audioManager.goalItemObject.transform.position.y * 2/3 ||
            Mathf.Abs(audioManager.p2Object.transform.position.y) < audioManager.goalItemObject.transform.position.y * 2/3)
        {
            if (q == 1)
            {
                PlayReceiveFail();
            }
            else if (q == 2)
            {
                Debug.Log("ok hit, zone 1-2  >temp< in sfxmanager");
            }
            else if (q == 3)
            {
                Debug.Log("perfect hit, zone 1-2 >temp< in sfxmanager");
            }
        }
        else if(audioManager.p1Object.transform.position.y > audioManager.goalItemObject.transform.position.y * 2 / 3 ||
                Mathf.Abs(audioManager.p2Object.transform.position.y) > audioManager.goalItemObject.transform.position.y * 2 / 3)
        {
            if (q == 1)
            {
                PlayReceiveFail();
            }
            else if (q == 2)
            {
                Debug.Log("ok hit, zone 3  >temp< in sfxmanager");
            }
            else if (q == 3)
            {
                hardReceive.Play();
            }
        }
    }

    //Transmission will have no fail sound
    //1 - from small height
    //2 - from med height
    //3 - from large height
    public void PlayTransmission(int level)
    {
        if (level == 1)
        {
            Debug.Log("transmission, zone 1 >temp< in sfxmanager");
        }
        else if (level == 2)
        {
            Debug.Log("transmission, zone 2 >temp< in sfxmanager");
        }
        else if (level == 3)
        {
            hardTransmission.Play();
        }
    }

    public void PlayReceiveFail()
    {
        receiveFail.Play();
    }
}
