using System;
using UnityEngine;
public class SimpleAudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource slowMoAudioSource;
    [SerializeField] private AudioSource bulletPassingAudioSource;
    [SerializeField] private AudioSource footStepAudioSource;
    [SerializeField] private AudioSource bulletHitAudioSource;
    [SerializeField] private AudioSource winAudioSource;

    private AudioListener _cameraAudioListner;

    private void Awake()
    {
        _cameraAudioListner = Camera.main.GetComponent<AudioListener>();
    }

    public void PlaySlowMoAudio(bool input)
    {
        if(input == false) slowMoAudioSource.Pause();
        else slowMoAudioSource.Play();
    }
    
    public void PlayBulletPassingAudio()
    {
        bulletPassingAudioSource.Play();
    }
    
    public void PlayFootStepAudioLoop(bool input)
    {
        if(input == false) footStepAudioSource.Pause();
        else footStepAudioSource.Play();
    }
    
    public void PlayBulletHitAudio()
    {
        bulletHitAudioSource.Play();
    }
    
    public void PlayWinAudio()
    {
        winAudioSource.Play();
    }

    public void MuteAudio(bool input)
    {
        if (input == true) AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }
    
    
    
}
