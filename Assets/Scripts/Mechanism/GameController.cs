using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject ResetWindow;
    public GameObject FinishWindow;
    // public GameObject SpiderWindow;

    public static int deathCount;
    public static bool canMove;
    public static bool GameFinish;
    public static bool PlayerDead;

    // public static bool ifTriggerSpider;
    public TextMeshProUGUI DeathText;
    private static int END_SCENE_INDEX = 31;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        PlayerStatus.respawnPos = GameObject.Find("AstroStay").transform.position;
        ResetWindow.SetActive(false);
        FinishWindow.SetActive(false);
        PlayerDead = false;
        GameFinish = false;
        //ResetButton.onClick.AddListener(ResetButtonesetClicked);
        //FirstTimeFailResetButton.onClick.AddListener(ResetClicked);
        //FinishButton.onClick.AddListener(FinishClicked);
    }

    void Update()
    {
        DeathText.text = "Death: " + deathCount;

        if (PlayerDead)
        {
            Time.timeScale = 0f;//Pause
            ResetWindow.SetActive(true);
        }
        if (GameFinish)
        {
            FinishWindow.SetActive(true);
            Time.timeScale = 0f;
        }
        // if (ifTriggerSpider){
        //    Time.timeScale = 0f;
        //    SpiderWindow.SetActive(true);
        // }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PlayerDead)deathCount++;
            Time.timeScale = 1f;
            ResetWindow.SetActive(false);
            PlayerDead = false;
            GameFinish = false;
            // GameObject Player = GameObject.Find("AstroStay");
            // Player.transform.position = PlayerStatus.respawnPos;
            // PlayerStatus.currHealth = PlayerStatus.maxHealth;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Time.timeScale = 1f;
            ResetWindow.SetActive(false);
            PlayerDead = false;
            GameFinish = false;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex != END_SCENE_INDEX)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }

            // if (currentSceneIndex + 1 > PlayerPrefs.GetInt("levelAt"))
            // {
            //     PlayerPrefs.SetInt("levelAt", currentSceneIndex + 1);
            // }
            canMove = true;
        }
    }
}
// Update is called once per frame
