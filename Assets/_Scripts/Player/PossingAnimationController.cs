using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PossingAnimationController : MonoBehaviour
{
    #region Variables

    private Animator _animator;


    private Queue<int> possingAnimationsToPlayQueue = new Queue<int>();
    [SerializeField] private GameInputs gameInputs;
    private float inputMultiplayer = 0.001f;

    private float minAnimationValue = 0;
    private float maxAnimationValue = 1;

    private float gestureValue;

    private float prePostureValue = 0;
    private float PostureValue;

    private string _randomPossingAnimationToPlay;

    [SerializeField] private bool ShouldDebugPossAnimation;
    [SerializeField] private int possAnimationToDebug;
    
    

    #endregion

    public void SetPostingOnTheMiddle() => prePostureValue = 0;


    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void AddToPossingAnimationQueu(int newValue)
    {
        possingAnimationsToPlayQueue.Enqueue(newValue);
    }

    public void ChoosePosingAnimationFromQueue()
    {
        int animationIntex = possingAnimationsToPlayQueue.Dequeue();
        Debug.Log("A_possing : " + animationIntex);
        switch (animationIntex)
        {
            case 1:
                _randomPossingAnimationToPlay = GameStrings.animator_state_poss1;
                break;
            case 2:
                _randomPossingAnimationToPlay = GameStrings.animator_state_poss2;
                break;
            case 3:
                _randomPossingAnimationToPlay = GameStrings.animator_state_poss3;
                break;
            case 4:
                _randomPossingAnimationToPlay = GameStrings.animator_state_poss4;
                break;
            default:
                Debug.Log("Invalid Animation -sabi");
                break;
        }
    }


    void Update()
    {
        if (GameManager.instance.GetCurentGameState() != AllGameStates.Possing) return;

        gestureValue = gameInputs.DOGetGestureValueUp();

        prePostureValue = Mathf.Clamp(prePostureValue + (gestureValue * inputMultiplayer), minAnimationValue,
            maxAnimationValue);
        PostureValue = Mathf.Clamp(prePostureValue, minAnimationValue, maxAnimationValue);

        _animator.Play(_randomPossingAnimationToPlay, -1, PostureValue);

        PostureValue += Time.deltaTime * 400;
    }
}