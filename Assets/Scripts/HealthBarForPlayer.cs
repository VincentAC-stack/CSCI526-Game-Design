using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HealthBarForPlayer : MonoBehaviour
{
    public int health;
    public int damage;
    public int maxHealth;
    public TextMeshProUGUI DeathText;

    void Update()
    {
        // Doesn't let the health go above Max Health
        if (health > maxHealth)
        {
            health = maxHealth;
            Debug.Log("maxHealth");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            health = health - damage;
        }

        if (health <= 0)
        {
            // Application.LoadLevel("Death");
            Debug.Log("dead since losing blood");
            GameController.PlayerDead = true;
            
        }
    }

    public void addHealth(int healthGainedFromEnemy)
    {
        if (health + healthGainedFromEnemy <= maxHealth)
        {
            health += healthGainedFromEnemy;
        }
        else
        {
            health = maxHealth;
        }
    }
}
