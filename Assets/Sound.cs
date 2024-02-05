using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip soundD;
    public static AudioClip sound;
    public static AudioSource audioSource;

    private void Start()
    {
        sound = soundD;
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    public static void playSound()
    {
        audioSource.PlayOneShot(sound);
    }
}
