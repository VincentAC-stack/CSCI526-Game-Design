using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    [SerializeField] GameObject pauseMenu;
    public void Pause() {
        pauseMenu.SetActive(true);
        GameController.canMove=false;
        Time.timeScale = 0f;
    }
    public void Reload() {

        if (GameController.PlayerDead) {
            GameController.deathCount++;
        }
        Time.timeScale = 1f;
        GameController.PlayerDead = false;
        GameController.GameFinish = false;
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.canMove = true;

    }
    public void Resume() {
        pauseMenu.SetActive(false);
        GameController.canMove=true;
        Time.timeScale = 1f;
    }
    public void Next() {
        Time.timeScale = 1f;
        GameController.PlayerDead = false;
        GameController.GameFinish = false;
        int idx = SceneManager.GetActiveScene().buildIndex;
        if (idx != 33)
        {
            SceneManager.LoadScene(idx + 1);
        }

        GameController.canMove = true;
    }
    public void Home(int index) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }

}
