using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SABI_Consol : MonoBehaviour
{
    public static SABI_Consol instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private List<string> logsList;
    [SerializeField] private string logs;

    public void Log(  string logMessage)
    {
        logs = (  logMessage ); 
    }
}