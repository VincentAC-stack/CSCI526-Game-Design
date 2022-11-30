using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] GameObject pauseMenu;
    
    void Start() {
        myAudio = Camera.main.GetComponent<AudioSource>();

    }
    public void Pause() {
        pauseMenu.SetActive(true);
        GameController.canMove=false;
        Time.timeScale = 0f;
        if(myAudio) {
            myAudio.Pause();
        }
    }
    public void Reload() {

        if (GameController.PlayerDead) {
            GameController.deathCount++;
        }
        Time.timeScale = 1f;
        GameController.PlayerDead = false;
        GameController.GameFinish = false;

        GameController.isWorldFlipped = false;
        GameController.flipFan = false;
        LaserControl.isAppear = true;
        LaserControlNew.isAppear = false;
        GameController.canMove = true;
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void Resume() {
        pauseMenu.SetActive(false);
        GameController.canMove=true;
        Time.timeScale = 1f;
        if(myAudio) {
            myAudio.Play();
        }
    }
    public void Next() {
        Time.timeScale = 1f;
        GameController.PlayerDead = false;
        GameController.GameFinish = false;
        int idx = SceneManager.GetActiveScene().buildIndex;
        
        GameController.isWorldFlipped = false;
        GameController.flipFan = false;
        LaserControl.isAppear = true;
        LaserControlNew.isAppear = false;
        GameController.deathCount = 0;
        GameController.canMove = true;
        if (idx != 23)
        {
            SceneManager.LoadScene(idx + 1);
        }

    }
    public void Home(int index) {
        Time.timeScale = 1f;

        GameController.PlayerDead = false;
        GameController.GameFinish = false;

        GameController.isWorldFlipped = false;
        GameController.flipFan = false;
        LaserControl.isAppear = true;
        LaserControlNew.isAppear = false;
        GameController.canMove = true;
        
        SceneManager.LoadScene(index);
        GameController.deathCount = 0;
    }

}
