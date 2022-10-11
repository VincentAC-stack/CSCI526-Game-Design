using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    static public float currentHealth;
    public Image Fill;

    void Start()
    {
        Fill = GetComponent<Image>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0f)
        {
            currentHealth = 0;
        }
        float fillAmount = currentHealth / maxHealth;
        Fill.fillAmount = fillAmount;
        if (currentHealth == 0)
        {
            GameController.canMove = false;
            GameController.PlayerDead = true;

        }
    }

}
