using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public static long _userId;

    void Start()
    {
        _userId = DateTime.Now.Ticks;
        Data.LevelDeaths = 0;
        Time.timeScale = 1f;
        
        // int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        //
        // for (int i = 0; i < levelBtns.Length; i++)
        // {
        //     if (i + 2 > levelAt)
        //     {
        //         levelBtns[i].interactable = false;
        //     }
        // }
    }
    public void LoadNextLevel(int index)
    {
        SceneManager.LoadScene(index);
        GameController.deathCount = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
