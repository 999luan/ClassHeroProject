using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip bgmMusic;

    private AudioManager audioM;
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();

        audioM.PlayBGM(bgmMusic);
    }

  
}
