using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMachine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            GameManager.instance.SetGameState(AllGameStates.OnComplete);
            
        }
    }
}
