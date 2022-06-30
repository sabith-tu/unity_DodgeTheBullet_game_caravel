using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AllOutlineStates
{
    NoOutline,
    GreenOutline,
    RedOutline,
}

public class PlayerOutlineController : MonoBehaviour
{
    [SerializeField] private Color redColor;
    [SerializeField] private Color greenColor;
    private AllOutlineStates _curentOutlineState;

    public void SetOutlineState(AllOutlineStates newState)
    {
        if (_curentOutlineState == newState) return;

        switch (newState)
        {
            case AllOutlineStates.NoOutline:
                break;
            case AllOutlineStates.GreenOutline:
                break;
            case AllOutlineStates.RedOutline:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    void NoOutlineState()
    {
    }

    void RedOutlineState()
    {
    }

    void GreenOutlineState()
    {
    }
}