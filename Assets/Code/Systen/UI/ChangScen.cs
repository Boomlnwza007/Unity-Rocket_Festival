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
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        audioSource.PlayOneShot(sound);
    }

    public void NextMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        audioSource.PlayOneShot(sound);

    }

    public void EndGame()
    {
        Time.timeScale = 1;
        Application.Quit();
        audioSource.PlayOneShot(sound);

    }
    //123
}
