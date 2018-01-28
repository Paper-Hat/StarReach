using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    void HideControls()
    {
        StartCoroutine(_HideControls());
    }

    IEnumerator _HideControls()
    {
        UnselectAll();
        for (int i = 0; i < controls.Length; i++)
        {
            controls[i].Play("Normal", 0);
            controls[i].Play("Exit", 1);
            yield return delay;
        }
    }

    GameObject nextMenu;
    public void SetNextMenu(GameObject nextMenu)
    {
        this.nextMenu = nextMenu;
    }

    void EnableNextMenu()
    {
        nextMenu.SetActive(true);
    }

    void UnselectAll()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
