using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameInputs : MonoBehaviour
{
    private float _fingerMovementUp;
    private float _fingerMovementRight;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        if (GameManager.instance.GetCurentGameState() != AllGameStates.Possing)
        {
            _fingerMovementUp = 0;
            _fingerMovementRight = 0;
            return;
        }

        if (Input.touchCount <= 0)
        {
            //_fingerMovementUp = 0.05f; 
            _fingerMovementUp = Time.timeScale;
            _fingerMovementRight = 0;
            return;
        }


        _fingerMovementUp = Input.GetTouch(0).deltaPosition.y;
        _fingerMovementRight = Input.GetTouch(0).deltaPosition.x;
    }

    public float DOGetGestureValueUp()
    {
        return _fingerMovementUp;
    }

    public float DOGetGestureValueRight()
    {
        return _fingerMovementRight;
    }
}