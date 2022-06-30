using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameManager gameManager;
    public static AudioManager instance;

    private void Awake() => instance = this;
    

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void PlayMusic(AudioClip music)
    {
        _musicSource.clip = music;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip sound, float vol = 1)
    {
        _soundSource.PlayOneShot(sound , vol);
    }
}
