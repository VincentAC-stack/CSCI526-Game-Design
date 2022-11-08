using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    private GameObject[] laser;
    public static bool isAppear = true;

    void Start()
    {
        laser = GameObject.FindGameObjectsWithTag("LaserWithParticle");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameController.canMove)
        {
            if (isAppear)
            {
                for (int i = 0; i < laser.Length; i++)
                {
                    laser[i].SetActive(false);
                    isAppear = false;
                }
            }
            else if (!isAppear)
            {
                for (int i = 0; i < laser.Length; i++)
                {
                    laser[i].SetActive(true);
                    isAppear = true;
                }
            }
        }
    }
}
