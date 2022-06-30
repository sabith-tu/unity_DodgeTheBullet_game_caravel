using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlood : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;

    [ContextMenu("Blood Effect")]
    public void PlayBloodEffect()
    {
        bloodEffect.Play();
    }
}
