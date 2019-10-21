using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSourceExtensions
{

    public static void Play(this AudioSource audio, AudioClip clip) {

        audio.clip = clip;
        audio.Play();

    }
    
}
