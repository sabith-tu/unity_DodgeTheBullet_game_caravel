using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float forceAmound;
    [SerializeField] private float delay;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    [ContextMenu("TestAffForce")]
    public void AddForceToGameObject()
    {
        _rigidbody.AddForce(transform.forward * forceAmound);
    }

    [ContextMenu("DelayTestAffForce")]
    public void AddForceToGameObjectWithDelay()
    {
        Invoke(nameof(AddForceToGameObject), delay);
    }
}