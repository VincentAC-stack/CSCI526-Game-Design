using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public int levelPage = 1;
    public GameObject prevButton;
    public GameObject nextButton;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // prevButton = GameObject.Find("prev_btn");
        prevButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {
        prevButton.SetActive(true);
        levelPage += 1;
        if (levelPage == 5)
        {
            nextButton.SetActive(false);
            // levelPage = 1;
        }
        Debug.Log(levelPage);
        LoadLevel();
    }
    
    public void PrevPage()
    {
        nextButton.SetActive(true);
        levelPage -= 1;
        if (levelPage == 1)
        {
            prevButton.SetActive(false);
            // levelPage = 1;
        }

        Debug.Log(levelPage);
        LoadLevel();
    }

    public void LoadLevel()
    {
        switch (levelPage)
        {
            case 1:
                page2.SetActive(false);
                page1.SetActive(true);
                break;
            case 2:
                page2.SetActive(true);
                page1.SetActive(false);
                page3.SetActive(false);
                break;
            case 3:
                page3.SetActive(true);
                page2.SetActive(false);
                page4.SetActive(false);
                break;
            case 4:
                page4.SetActive(true);
                page3.SetActive(false);
                page5.SetActive(false);
                break;
            case 5:
                page5.SetActive(true);
                page4.SetActive(false);
                break;
            default:
                page1.SetActive(true);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                break;
        }
        
    }
    
    
}
