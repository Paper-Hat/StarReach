using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TwoClickButton : Button
{
    Animator anim;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsInteractable())
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
            {
                base.OnPointerClick(eventData);
            }
            anim.Play("Highlighted");
            Select();
        }
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}

/*public class TwoClickButton : MonoBehaviour, IPointerClickHandler {

    Button button;
    EventSystem es;
    public UnityEvent onHighlightedClick;

    void Start()
    {
        button = GetComponent<Button>();
        es = EventSystem.current;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (es.currentSelectedGameObject == gameObject)
        {
            Debug.Log("Select clicked");
            onHighlightedClick.Invoke();
        }
    }
}*/
