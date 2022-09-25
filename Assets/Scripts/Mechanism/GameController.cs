using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ResetWindow;
    public GameObject FirstTimeFailWindow;
    public GameObject FinishWindow;
    public Button ResetButton;
    public Button FirstTimeFailResetButton;
    public Button FinishButton;
	public static bool canMove;
	public static bool flipped;
	
	
    // Start is called before the first frame update
    void Start()
    {
		canMove = true;
        //ResetButton.onClick.AddListener(ResetButtonesetClicked);
        //FirstTimeFailResetButton.onClick.AddListener(ResetClicked);
        //FinishButton.onClick.AddListener(FinishClicked);
    }
    

    private void ResetClicked()
    {
        
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // print("Restart the game");
    }

    private void FinishClicked()
    {
        
        
        // print("Finish the game");
    }
	void Update(){
		if (Input.GetKeyDown(KeyCode.R))
        {
			FinishWindow.SetActive(false);
			ResetWindow.SetActive(false);
			FirstTimeFailWindow.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			GameController.canMove = true;
        }
	}
}
// Update is called once per frame

