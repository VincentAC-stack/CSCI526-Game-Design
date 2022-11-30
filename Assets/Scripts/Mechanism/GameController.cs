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
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject textWindow;

    public static int deathCount;
    public static bool canMove;
    public static bool GameFinish;
    public static bool PlayerDead;

    // public static bool ifTriggerSpider;
    public TextMeshProUGUI DeathText;
    private static int END_SCENE_INDEX = 23;

    public static bool isWorldFlipped;
    public static bool flipFan;
    
    public Transform player;
    
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
            isWorldFlipped = false;
            flipFan = false;
            LaserControl.isAppear = true;
            LaserControlNew.isAppear = false;
        }
        if (GameFinish)
        {
            FinishWindow.SetActive(true);
            Time.timeScale = 0f;
            
            // three.SetActive(true);
            int playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthBarForPlayer>().health;
            Debug.Log(playerHealth);
            if (playerHealth >= 50)
            {
                three.SetActive(true);
            }
            if (playerHealth < 50 &&  playerHealth > 20)
            {
                two.SetActive(true);
            }
            if (playerHealth <= 20)
            {
                one.SetActive(true);
            }
            isWorldFlipped = false;
            flipFan = false;
            LaserControl.isAppear = true;
            LaserControlNew.isAppear = false;
        }
        
         if (Input.GetKeyDown(KeyCode.Return))
         {
             Time.timeScale = 1f;
             GameObject[] tutorialsWindows;
             tutorialsWindows = GameObject.FindGameObjectsWithTag("tutorialCheckpoint");
             foreach (GameObject tw in tutorialsWindows)
             {
                 tw.SetActive(false);
             }
             canMove = true;
         }
       
        
        // if (ifTriggerSpider){
        //    Time.timeScale = 0f;
        //    SpiderWindow.SetActive(true);
        // }
        // if (Input.GetKeyDown(KeyCode.R)) //Change to button click
        // {
        //     if (PlayerDead)deathCount++;
        //     Time.timeScale = 1f;
        //     ResetWindow.SetActive(false);
        //     PlayerDead = false;
        //     GameFinish = false;
        //     
        //     // Player.GetComponent<HealthBarForPlayer>().addHealth(100);
        //     // PlayerStatus.currHealth = PlayerStatus.maxHealth;
        //     // Reset the world if the world has been flipped
        //     
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //     canMove = true;
        // }
        // if (Input.GetKeyDown(KeyCode.N)) //Change to button click
        // {
        //     Time.timeScale = 1f;
        //     ResetWindow.SetActive(false);
        //     PlayerDead = false;
        //     GameFinish = false;
        //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //     if (currentSceneIndex != END_SCENE_INDEX)
        //     {
        //         SceneManager.LoadScene(currentSceneIndex + 1);
        //     }
        //
        //     // if (currentSceneIndex + 1 > PlayerPrefs.GetInt("levelAt"))
        //     // {
        //     //     PlayerPrefs.SetInt("levelAt", currentSceneIndex + 1);
        //     // }
        //     canMove = true;
        // }
    }
}
// Update is called once per frame
