using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float staminaPoints = 50.0f;
    public float maxStaminaPoints = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PickupObject") || col.gameObject.CompareTag("CoinPickupObject"))
        {
            Item hitObject = col.gameObject.GetComponent<Pickup>().item;
            if (hitObject != null)
            {
                Debug.Log(hitObject.itemName);
                hitObject.quantity += 1;
            }
            col.gameObject.SetActive(false);
        }
    }
}
