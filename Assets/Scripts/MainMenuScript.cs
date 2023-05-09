using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainUI;

    public void Awake()
    {
        Time.timeScale = 0f;
    }
    
    public void Play()
    {
        Toggle();
    }
    public void Toggle()
    {
        mainUI.SetActive(!mainUI.activeSelf);

        if (mainUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Quit()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }
}
