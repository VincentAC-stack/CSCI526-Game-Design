using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopTutorial : MonoBehaviour
{
    private bool istriggered = false;
    public GameObject textWindow;
    void Start()
    {
    }
    
    void Update()
    {
        // Debug.Log("Collision!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if  (istriggered == false  && col.name.Contains("AstroStay")){
            istriggered = true;
            textWindow.SetActive(true);
            Time.timeScale = 0f;
            GameController.canMove = false;
        }
        
    }
    
}

