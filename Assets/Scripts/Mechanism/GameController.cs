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

    // Start is called before the first frame update
    void Start()
    {
        ResetButton.onClick.AddListener(ResetClicked);
        FirstTimeFailResetButton.onClick.AddListener(ResetClicked);
        FinishButton.onClick.AddListener(FinishClicked);
    }

    private void ResetClicked()
    {
        
        ResetWindow.SetActive(false);
        FirstTimeFailWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // print("Restart the game");
    }

    private void FinishClicked()
    {
        FinishWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // print("Finish the game");
    }
}
// Update is called once per frame

