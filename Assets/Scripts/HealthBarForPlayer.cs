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
    public float jumpForceX = 0;
    public float jumpForceY = 3;

    public HealthBarBackup healthBarBackup;

    void Start()
    {
        //health = maxHealth;
        healthBarBackup.SetMaxHealth(maxHealth);
        healthBarBackup.SetHealth(health);
    }

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
        if (collision.gameObject.name=="Bullet(Clone)"|| collision.gameObject.name == "BulletForMonster(Clone)")
        {
            health = health - damage;
            healthBarBackup.SetHealth(health);
            ReduceHealthData.bulletCount++;
        }

        if (health <= 0)
        {
            // Application.LoadLevel("Death");
            Debug.Log("dead since losing blood");
            GameController.PlayerDead = true;

        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Spike"))
        {
            health = health - damage;
            healthBarBackup.SetHealth(health);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
            ReduceHealthData.spikeCount++;
        }
        
        if (col.gameObject.name.Contains("Saw"))
        {
            health = health - damage;
            healthBarBackup.SetHealth(health);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
            ReduceHealthData.sawCount++;
        }
        
        if (col.gameObject.name.Contains("Crystal"))
        {
            health = health - damage;
            healthBarBackup.SetHealth(health);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
            ReduceHealthData.crystalCount++;
        }

        if (col.gameObject.name.Contains("Laser"))
        {
            if (col.gameObject.transform.position.y > this.transform.position.y)
            {
                health = health - damage;
                healthBarBackup.SetHealth(health);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, -jumpForceY), ForceMode2D.Impulse);
                ReduceHealthData.laserCount++;
            }
            else
            {
                health = health - damage;
                healthBarBackup.SetHealth(health);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
                ReduceHealthData.laserCount++;
            }
        }
        if (col.gameObject.name == "DownFailChecker" || col.gameObject.name == "DownFailChecker2") 
        {
            health = health - damage;
            healthBarBackup.SetHealth(health);
            if (health > 0)
            {
                if (GameController.isWorldFlipped) {
                    FlipWorld.Flip();
                    GameController.flipFan = !GameController.flipFan;
                    GameController.isWorldFlipped = !GameController.isWorldFlipped;
                }
                GameObject Player = GameObject.Find("AstroStay");
                Player.transform.position = Move2D.respawnPoint;
            }
        }
        // if (col.gameObject.name.Contains("Laser") && !col.gameObject.name.Contains("Up") && !col.gameObject.name.Contains("Down"))
        // {
        //     health = health - damage;
        //     healthBarBackup.SetHealth(health);
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
        //     ReduceHealthData.laserCount++;
        // }
        //
        // if (col.gameObject.name.Equals("LaserWithParticleDown"))
        // {
        //     health = health - damage;
        //     healthBarBackup.SetHealth(health);
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, -jumpForceY), ForceMode2D.Impulse);
        //     ReduceHealthData.laserCount++;
        // }
        //
        // if (col.gameObject.name.Equals("LaserWithParticleUp"))
        // {
        //     health = health - damage;
        //     healthBarBackup.SetHealth(health);
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
        //     ReduceHealthData.laserCount++;
        // }
        
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
            healthBarBackup.SetHealth(health);
        }
        else
        {
            health = maxHealth;
            healthBarBackup.SetMaxHealth(maxHealth);
        }
    }


    public void decreaseHealth(int dmg)
    {
        health -= dmg;
        healthBarBackup.SetHealth(health);
        if (health <= 0)
        {
            GameController.PlayerDead = true;
            GameController.canMove = false;
        }

    }

    public int getCurrentHealth(){
      return health;
    }

}
