using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlNew : MonoBehaviour
{
    private GameObject laser;
    public bool isAppear = false;

    void Start()
    {
        laser = GameObject.FindGameObjectWithTag("LaserWithParticleNew");
        laser.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameController.canMove)
        {
            if (isAppear)
            {
                laser.SetActive(false);
                isAppear = false;
            }
            else if (!isAppear)
            {
                laser.SetActive(true);
                isAppear = true;
            }
        }
    }
}
