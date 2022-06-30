using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutlineColor : MonoBehaviour
{
    [SerializeField] private cakeslice.Outline _outline;
    private void Awake()
    {
        
    }

    public void SetOutlineColorRed()
    {
        if(_outline.color == 2) _outline.color = 1;
    }

    public void SetOutlineColorGreen()
    {
        if(_outline.color == 1) _outline.color = 2;
    }
}
