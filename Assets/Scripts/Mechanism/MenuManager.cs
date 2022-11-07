using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;
using UnityEngine.SceneManagement;
using static GameController;

public class MenuManager : MonoBehaviour
{

    public static long _userId;
    private static int END_SCENE_INDEX = 33;

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
    
    public void EnterNextLevel()
    {
        Time.timeScale = 1f;
        // ResetWindow.SetActive(false);
        PlayerDead = false;
        GameFinish = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != END_SCENE_INDEX)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
        canMove = true;
    }
    
    public void ReplayLevel()
    {
        if (PlayerDead);
        Time.timeScale = 1f;
        // ResetWindow.SetActive(false);
        PlayerDead = false;
        GameFinish = false;
            
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canMove = true;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
