using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlNew : MonoBehaviour
{
    private GameObject[] laser;
    public bool isAppear = false;

    void Start()
    {
        laser = GameObject.FindGameObjectsWithTag("LaserWithParticleNew");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameController.canMove)
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
