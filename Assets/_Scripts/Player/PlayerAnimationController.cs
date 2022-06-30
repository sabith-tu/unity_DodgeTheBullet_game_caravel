using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetAnimatorSpeedForPossing() => _animator.speed = 1;
    public void SetAnimatorSpeedForRunning() => _animator.speed = 1;
    
    public void SetAnimatiorForPossing()
    {
        _animator.SetBool(GameStrings.animator_condition_poss,true);
        _animator.SetBool(GameStrings.animator_condition_run,false);
    }
    
    public void SetAnimatiorForDeath()
    {
        _animator.SetTrigger(GameStrings.animator_condition_DeathTrigger);
    }
    
    public void SetAnimatiorForPunch()
    {
        _animator.SetTrigger(GameStrings.animator_condition_PunchTrigger);
    }

    public void SetAnimatiorForRunning()
    {
        _animator.SetBool(GameStrings.animator_condition_poss,false);
        _animator.SetBool(GameStrings.animator_condition_run,true);
    }
}
