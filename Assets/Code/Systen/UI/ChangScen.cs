using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScen : MonoBehaviour
{
    public void NextGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
