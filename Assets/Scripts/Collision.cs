using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public float health = 100f;

    private void Update()
    {
        if (health == 0)
        {
            GameController.canMove = false;
            GameController.PlayerDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Spike"))
        {
            Debug.Log("HIT");
            HealthBar.currentHealth -= 25;
        }
        if (col.gameObject.name.Contains("Saw"))
        {
            HealthBar.currentHealth -= 25;
        }

        if (col.gameObject.name == "DownFailChecker")
        {
            // GameController.canMove = false;
            // GameController.PlayerDead = true;
            HealthBar.currentHealth = 0;
            Data.GameResult = false;
            Data.LevelDeaths = -1;
            // Send()
        }

    }
    
}
