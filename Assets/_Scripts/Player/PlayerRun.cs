using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRun : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float playerSpeed;

    //[SerializeField] private Slider _slider;
    [SerializeField] private GameInputs _gameInputs;
    private float inputMultiplayer = 0.001f;

    private float preSideValue = 0;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        //if(GameManager.instance.GetCurentGameState() == AllGameStates.OnComplete) return;
        
        if (GameManager.instance.GetCurentGameState() == AllGameStates.Running || GameManager.instance.GetCurentGameState() == AllGameStates.Possing)
        {
            //Debug.Log(GameManager.instance.GetCurentGameState());
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }
    }
}