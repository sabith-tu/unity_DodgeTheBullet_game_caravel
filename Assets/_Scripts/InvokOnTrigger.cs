using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokOnTrigger : MonoBehaviour
{
    [SerializeField] private string tag;
    [SerializeField] private UnityEvent EventToInvoke;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            EventToInvoke.Invoke();
        }
    }
}
