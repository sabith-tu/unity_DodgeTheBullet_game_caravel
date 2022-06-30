using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TRIGGER ENTER");
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetGameState(AllGameStates.OnHit);

            //Debug.Log("__HIT__");
        }
    }
}