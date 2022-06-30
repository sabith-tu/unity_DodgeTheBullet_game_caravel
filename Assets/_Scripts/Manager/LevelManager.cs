using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float delayBtwScenarios = 3;

    [SerializeField] private UnityEvent OnLevel1;
    [SerializeField] private UnityEvent OnLevel2;
    [SerializeField] private UnityEvent OnLevel3;
    [SerializeField] private UnityEvent OnLevel4;

    private void Start()
    {
        // RandomScenarioAndAnimation();
        // Invoke(nameof(RandomScenarioAndAnimation),11);
        // Invoke(nameof(RandomScenarioAndAnimation),18);
        // Invoke(nameof(RandomScenarioAndAnimation),26);
        // Invoke(nameof(RandomScenarioAndAnimation),30);
        //Invoke(nameof(RepeatedLevelScenarios),6);
        RepeatedLevelScenarios();
    }

    public void RepeatedLevelScenarios()
    {
        InvokeRepeating(nameof(RandomScenarioAndAnimation), -1, delayBtwScenarios);
    }


    public void RandomScenarioAndAnimation()
    {
        if (GameManager.instance.GetCurentGameState() != AllGameStates.Running) return;

        int randomInt = Random.Range(1, 5);
        //int randomInt = 2;
        //Debug.Log("LM : " + randomInt);

        switch (randomInt)
        {
            case 1:
                OnLevel1.Invoke();
                break;
            case 2:
                OnLevel2.Invoke();
                break;
            case 3:
                OnLevel3.Invoke();
                break;
            case 4:
                OnLevel4.Invoke();
                break;
        }
    }

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}