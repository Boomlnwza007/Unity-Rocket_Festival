using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemCon : MonoBehaviour
{
    public bool Show = false;
    [SerializeField]public GameObject menuobj;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
    }

    public void Menu()
    {
        if (!Show)
        {
            Show = true;
            Time.timeScale = 0;
            menuobj.SetActive(true);
        }
        else
        {
            Show = false;
            Time.timeScale = 1;
            menuobj.SetActive(false);
        }
    }
}
