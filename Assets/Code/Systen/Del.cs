using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    public void Delete()
    {
        Destroy(gameObject);
    }

    public void playSound()
    {
        audioSource.PlayOneShot(sound);
    }
}
