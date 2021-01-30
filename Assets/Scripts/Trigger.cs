using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public UnityEvent OnTriggerEnter;

    // void Start() { }
    // void Update() { }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (OnTriggerEnter != null)
        {
            OnTriggerEnter.Invoke();
        }
    }
}
