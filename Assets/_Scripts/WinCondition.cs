using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private bool win;

    void Awake()
    {
        win = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        win = true;
    }

    void FixedUpdate()
    {
        
    }
}
