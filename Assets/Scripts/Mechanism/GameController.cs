using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ResetWindow;
    public GameObject FinishWindow;
    public static bool canMove;
	public static bool flipped;
	public static bool GameFinish;
	public static bool PlayerDead;
	
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
    void Update(){
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
    }
}
// Update is called once per frame

