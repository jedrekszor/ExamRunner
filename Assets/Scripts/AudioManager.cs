using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource soundtrack;
    private static AudioSource sounds;

    public static void PlaySoundtrack(AudioClip clip)
    {
        soundtrack.clip = clip;
        soundtrack.Play();
    }

    public static void PlaySound(AudioClip clip)
    {
        sounds.clip = clip;
        sounds.PlayOneShot(sounds.clip);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        soundtrack = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        sounds = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }
}
