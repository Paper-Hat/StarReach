using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericMenu : MonoBehaviour {

    public Animator[] controls;
    WaitForSeconds delay = new WaitForSeconds(0.07f);

    void ShowControls()
    {
        StartCoroutine(_ShowControls());
    }

	IEnumerator _ShowControls()
    {
        for (int i = 0; i < controls.Length; i++)
        {
            controls[i].gameObject.SetActive(true);
            controls[i].Play("Enter", 1);
            yield return delay;
        }
    }
}
