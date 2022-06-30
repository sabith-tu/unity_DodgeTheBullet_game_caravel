using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuBasedCheatCodes : MonoBehaviour
{
    [ContextMenu("GameStatePossing")]
    public void GameStatePossing()
    {
        GameManager.instance.SetGameState(AllGameStates.Possing);
    }

    [ContextMenu("GameStateRunning")]
    public void GameStateRunning()
    {
        GameManager.instance.SetGameState(AllGameStates.Running);
    }
    
    [ContextMenu("GameStateUI")]
    public void GameStateUI()
    {
        GameManager.instance.SetGameState(AllGameStates.UI);
    }
}