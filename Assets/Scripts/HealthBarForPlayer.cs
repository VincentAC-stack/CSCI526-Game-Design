using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using Unity.VisualScripting;

public class HealthBarForPlayer : MonoBehaviour{

  public int health;
  public int damage;
  public int maxHealth;
  public TextMeshProUGUI DeathText;

  void Update(){
    if (health > maxHealth)
    {
        health = maxHealth;
        Debug.Log("maxhealth");
    }

  }

  void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("Bullet"))
      {
          health = health - damage;


      }

      if (health <= 0)
      {
          // Application.LoadLevel("Death");

          Debug.Log("deadth since losing blood");
          GameController.canMove = false;
          GameController.PlayerDead = true;
          GameController.deathCount += 1;
          Debug.Log(GameController.deathCount);

      }
      // Doesen't let the health go above Max Health


  }




}
