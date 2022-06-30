using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum AllUiStates
{
    MainMenu,
    GamePlay,
    PauseMenu,
    Settings,
    Failed,
    Won
}

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiGamePlay;
    [SerializeField] private GameObject uiPauseMenu;
    [SerializeField] private GameObject uiSettings;
    [SerializeField] private GameObject uiFailed;
    [SerializeField] private GameObject uiWon;

    [Space(20)] [SerializeField] private Slider distanceSlider;
    [SerializeField] private Transform player;
    [SerializeField] private Transform runningDestination;

    private float _maxDistanceToRunForThePlayer;

    private AllUiStates _curentUiState = AllUiStates.MainMenu;

    public AllUiStates DoGetCurentUiState()
    {
        return _curentUiState;
    }


    public void DoSetCurentUiStateToMainMenu() => DoSetCurentUiState(AllUiStates.MainMenu);
    public void DoSetCurentUiStateToGamePlay() => DoSetCurentUiState(AllUiStates.GamePlay);
    public void DoSetCurentUiStateToPauseMenu() => DoSetCurentUiState(AllUiStates.PauseMenu);
    public void DoSetCurentUiStateToWon() => DoSetCurentUiState(AllUiStates.Won);
    public void DoSetCurentUiStateToFailed() => DoSetCurentUiState(AllUiStates.Failed);

    public void FaileScreenWithPauseInDelay()
    {
        Invoke(nameof(DoSetCurentUiStateToFailed), 1);
        Invoke(nameof(DoPauseGame), 1);

        void DoPauseGame() => GameManager.instance.PauseGame(true);
    }

    public void WinScreenWithPauseInDelay()
    {
        Invoke(nameof(DoSetCurentUiStateToWon), 1);
        //Invoke(nameof(DoPauseGame), 1);
    }
    //void DoPauseGame() => GameManager.instance.PauseGame(true);


    public void DoSetCurentUiState(AllUiStates newUiState)
    {
        //if (newUiState == _curentUiState) return;
        DisableOldUiState(_curentUiState);
        _curentUiState = newUiState;
        EnableNewUiState(_curentUiState);
    }

    private void DisableOldUiState(AllUiStates uiStateToDisable)
    {
        switch (uiStateToDisable)
        {
            case AllUiStates.MainMenu:
                uiMainMenu.SetActive(false);
                break;
            case AllUiStates.GamePlay:
                uiGamePlay.SetActive(false);
                break;
            case AllUiStates.PauseMenu:
                uiPauseMenu.SetActive(false);
                break;
            case AllUiStates.Settings:
                uiSettings.SetActive(false);
                break;
            case AllUiStates.Failed:
                uiFailed.SetActive(false);
                break;
            case AllUiStates.Won:
                uiWon.SetActive(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void EnableNewUiState(AllUiStates uiStateToEnable)
    {
        switch (uiStateToEnable)
        {
            case AllUiStates.MainMenu:
                uiMainMenu.SetActive(true);
                break;
            case AllUiStates.GamePlay:
                uiGamePlay.SetActive(true);
                break;
            case AllUiStates.PauseMenu:
                uiPauseMenu.SetActive(true);
                break;
            case AllUiStates.Settings:
                uiSettings.SetActive(true);
                break;
            case AllUiStates.Failed:
                uiFailed.SetActive(true);
                break;
            case AllUiStates.Won:
                uiWon.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Awake()
    {
        instance = this;
        _maxDistanceToRunForThePlayer = Vector3.Distance(player.position, runningDestination.position);
    }

    private void Update()
    {
        float distanceCoveredByPlayer = Vector3.Distance(player.position, runningDestination.position) /
                                        _maxDistanceToRunForThePlayer;

        DoSetSliderValue(1 - distanceCoveredByPlayer);
    }

    public void DoSetSliderValue(float input)
    {
        distanceSlider.value = input;
        //distanceSlider.DOValue(input, 0.05f);
    }
}