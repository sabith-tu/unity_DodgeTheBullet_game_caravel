using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _enemy;
    [Range(-1, -11)] public float axisZoffset;
    [Range(0.1f, 3f)] public float enemyAxisZoffsetMultiplayer;
    [SerializeField] private AllCameraStates _curentCameraState = AllCameraStates.FollowPlayerState; //_______________________________
    [SerializeField] private Vector3 lookAtPunchPossitionOffset;
    [SerializeField] private Vector3 lookAtPunchRotationOffset;

    private Vector3 cameraStartingPossition;
    private Vector3 cameraStartingRotation;

    [SerializeField] private float delayBwtLookAtPunchAndNormalAngle = 1;

    public void SetCameraStateToFollowPlayer() => DoSetCameraState(AllCameraStates.FollowPlayerState);
    public void SetCameraStateToFollowEnemy() => DoSetCameraState(AllCameraStates.FollowEnemyState);
    public void SetCameraStateToLookAtPunch() => DoSetCameraState(AllCameraStates.LookAtPunchState);

    private void Start()
    {
        cameraStartingPossition = transform.position;
        cameraStartingRotation = transform.eulerAngles;
    }

    public void SetCameraStateToPunchPositionAndFollowEnemyWithDelay()
    {
        SetCameraStateToLookAtPunch();
        Invoke(nameof(SetCameraStateToFollowEnemy),delayBwtLookAtPunchAndNormalAngle + 0.01f);
    }


    public void DoSetCameraState(AllCameraStates newState)
    {
        if(_curentCameraState == newState) return;

        _curentCameraState = newState;
        switch (newState)
        {
            case AllCameraStates.FollowPlayerState:
                break;
            case AllCameraStates.LookAtPunchState:
                
                transform.DOMove(transform.position + lookAtPunchPossitionOffset , 0.4f);
                transform.DORotate(transform.eulerAngles + lookAtPunchRotationOffset, 0.4f);

                cameraStartingPossition.z = transform.position.z;
                transform.DOMove(cameraStartingPossition , 0.1f).SetDelay(delayBwtLookAtPunchAndNormalAngle);
                transform.DORotate(cameraStartingRotation, 0.1f).SetDelay(delayBwtLookAtPunchAndNormalAngle);
                
                break;
            case AllCameraStates.FollowEnemyState:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    


    private void LateUpdate()
    {
        
        // if (GameManager.instance.GetCurentGameState() == AllGameStates.OnComplete)
        // {
        //     //Debug.Log("OnCompleteCameraMovement");
        //     transform.DOMove(new Vector3(_enemy.position.x, transform.position.y,
        //         _enemy.position.z + (axisZoffset * 1.5f)), 1);
        // }
        // else if(_curentCameraState == AllCameraStates.FollowPlayerState)
        // {
        //     transform.position =
        //         new Vector3(transform.position.x, transform.position.y, _player.position.z + axisZoffset);
        // }
        
        
        if (_curentCameraState == AllCameraStates.FollowEnemyState)
        {
            transform.DOMove(
               // new Vector3(_enemy.position.x, transform.position.y,
               new Vector3(0.21f, 7.8f,
                _enemy.position.z + (axisZoffset * enemyAxisZoffsetMultiplayer)), 1);
        }
        else if(_curentCameraState == AllCameraStates.FollowPlayerState)
        {
            transform.position =
                new Vector3(transform.position.x, transform.position.y, _player.position.z + axisZoffset);
                //new Vector3(0.21f, 7.8f, _player.position.z + axisZoffset);
        }
    }
}

public enum AllCameraStates
{
    FollowPlayerState,
    LookAtPunchState,
    FollowEnemyState
}