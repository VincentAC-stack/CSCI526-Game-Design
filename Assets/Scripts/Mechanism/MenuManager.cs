using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public static long _userId;

    private void Start()
    {
        _userId = DateTime.Now.Ticks;
    }
    public void LoadNextLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
