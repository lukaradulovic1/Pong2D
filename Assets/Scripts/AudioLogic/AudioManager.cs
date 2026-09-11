using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioMusic;
    public AudioClip backgroundMusic;
    public AudioSource paddleHitSource;
    public AudioClip paddleHitClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        audioMusic = GetComponent<AudioSource>();
        audioMusic.Play();
    }

    public void PlayPaddleHit()
    {
        paddleHitSource.PlayOneShot(paddleHitClip);
    }

    
}
