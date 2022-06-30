
using System;
using UnityEngine;
using UnityEngine.Events;

public enum AllGameStates
{
    Running,
    Possing,
    OnHit,
    OnComplete,
    UI
}
public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnPossingState;
    [SerializeField] UnityEvent OnRunningState;
    [SerializeField] UnityEvent OnUIState;
    [SerializeField] UnityEvent OnHitState;
    [SerializeField] UnityEvent OnCompleteState;
    public static GameManager instance { get; private set; }
    
    References _references;
    UiManager _uiManager;
    AudioManager _audioManager;
    private CameraManager _cameraManager;
    //private AllGameStates _currentGameState = AllGameStates.Possing;
    [SerializeField] private AllGameStates _currentGameState = AllGameStates.Running;

    public bool IsGamePaused { get; private set; } = false;

    
    private void Awake()
    {
        instance = this;
        _references = GetComponent<References>();
        _uiManager = GetComponent<UiManager>();
        _audioManager = transform.parent.GetComponentInChildren<AudioManager>();
        
    }

    private void Start()
    {
        SetGameState(_currentGameState);
        UiManager.instance.DoSetCurentUiState(AllUiStates.MainMenu);
        PauseGame(true);
        
        Debug.Log("Can you hear me ? ");
    }
    
    public AllGameStates GetCurentGameState()
    {
        return _currentGameState;
    }

    public void SetGameState(AllGameStates newGameState)
    {
        if(_currentGameState == newGameState) return;
        
        _currentGameState = newGameState;
        switch (newGameState)
        {
            case AllGameStates.Running:
                OnRunningState.Invoke();
                break;
            case AllGameStates.Possing:
                OnPossingState.Invoke();
                break;
            case AllGameStates.UI:
                OnUIState.Invoke();
                break;
           case AllGameStates.OnHit:
                OnHitState.Invoke();
                Debug.Log("Hit State");
                break;
             case AllGameStates.OnComplete:
                 OnCompleteState.Invoke();
                break;
            default:
                Debug.Log("Game state is invalid");
                throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
        }
    }

    public void SetGameStateToRunning() => SetGameState(AllGameStates.Running);
    public void SetGameStateToPossing() => SetGameState(AllGameStates.Possing);


    public void PauseGame(bool shouldPause)
    {
        if (shouldPause)
        {
            Debug.Log("_____________ Game Paused _______________");
            IsGamePaused = true;
            Time.timeScale = 0;
        }
        else 
        {
            Debug.Log("_____________ Game Resumed ________________");
            IsGamePaused = false;
            Time.timeScale = 1;
        }
    }
}
