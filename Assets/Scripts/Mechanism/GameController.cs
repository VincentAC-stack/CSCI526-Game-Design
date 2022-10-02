using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ResetWindow;
    public GameObject FinishWindow;
    public static int deathCount;
    public static bool canMove;
    public static bool GameFinish;
    public static bool PlayerDead;

    private static int END_SCENE_INDEX = 5;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        //ResetButton.onClick.AddListener(ResetButtonesetClicked);
        //FirstTimeFailResetButton.onClick.AddListener(ResetClicked);
        //FinishButton.onClick.AddListener(FinishClicked);
    }

    public GameObject getResetWindow()
    {
        return ResetWindow;
    }
    void Update()
    {
        if (PlayerDead)
        {
            ResetWindow.SetActive(true);
            Time.timeScale = 0f; //Pause
        }
        if (GameFinish)
        {
            FinishWindow.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            ResetWindow.SetActive(false);
            PlayerDead = false;
            GameFinish = false;
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
            canMove = true;
        }
    }
}
// Update is called once per frame
