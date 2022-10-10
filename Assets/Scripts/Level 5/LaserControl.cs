using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public GameObject laser;
    public static bool isAppear = true;

    void Start()
    {
        laser = GameObject.Find("LaserWithParticle");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
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
