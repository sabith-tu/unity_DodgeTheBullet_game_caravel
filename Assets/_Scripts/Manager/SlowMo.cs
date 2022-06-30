using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum AllTimeState
{
    GoSlow,
    Normal
}

public class SlowMo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    [SerializeField] private Slider _slider;

    //private AllTimeState _curentTimeState = AllTimeState.Normal;
    private AllTimeState _curentTimeState = AllTimeState.Normal;
    private float _timeScaleCopy;
    [SerializeField] [Range(0.01f, 0.9f)] private float SlowDownTo = 0.1f;
    [SerializeField] [Range(0.1f, 5)] float timeChangeSpeedToSloMo;
    [SerializeField] [Range(0.1f, 5)] float timeChangeSpeedToNormal;
    [SerializeField] private float delay = 0.25f;


    private void Update()
    {
        switch (_curentTimeState)
        {
            case AllTimeState.GoSlow:
                if (GameManager.instance.IsGamePaused) return;
                if (Time.timeScale > SlowDownTo)
                {
                    Time.timeScale = Mathf.MoveTowards(Time.timeScale, SlowDownTo,
                        timeChangeSpeedToSloMo * Time.unscaledDeltaTime);
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                }
                else
                {
                    Time.timeScale = SlowDownTo;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                }

                break;
            case AllTimeState.Normal:
                if (GameManager.instance.IsGamePaused) return;
                if (Time.timeScale < 0.9f)
                {
                    Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1,
                        timeChangeSpeedToNormal * Time.unscaledDeltaTime);
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                }
                else
                {
                    Time.timeScale = 1;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                }

                break;
        }

        _slider.value = Time.timeScale;
        
    /*
    Time.timeScale = 0.05f;
    Time.fixedDeltaTime = Time.timeScale * 0.02f;
    */
    
    }


    public void SlowTime()
    {
        _curentTimeState = AllTimeState.GoSlow;
    }

    public void NormalTimeScale()
    {
        _curentTimeState = AllTimeState.Normal;
    }

    public void SlowDownAndNormalTimeWithDelay()
    {
        SlowTime();
        Invoke(nameof(NormalTimeScale),delay);
    }

    private void Start()
    {
    }
}