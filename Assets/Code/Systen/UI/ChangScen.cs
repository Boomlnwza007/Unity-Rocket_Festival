using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScen : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    public void NextGame()
    {
        SceneManager.LoadScene(1);
        audioSource.PlayOneShot(sound);
        Time.timeScale = 1;
    }

    public void NextMenu()
    {
        SceneManager.LoadScene(0);
        audioSource.PlayOneShot(sound);
        Time.timeScale = 1;

    }

    public void EndGame()
    {
        Application.Quit();
        audioSource.PlayOneShot(sound);
        Time.timeScale = 1;

    }
    //123
}
