using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTheBulletInSeconds;
    private void Start()
    {
        Destroy(this.gameObject,destroyTheBulletInSeconds);
    }
}
