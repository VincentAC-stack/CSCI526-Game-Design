using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;

public class MenuManager : MonoBehaviour
{

    public static long _userId;

    void Start()
    {
        _userId = DateTime.Now.Ticks;
        
        if (GetActiveScene().buildIndex == 1)
        {
            ReduceHealthData.deathCount = 0;
        }
        

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
        LoadScene(index);
        GameController.deathCount = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
