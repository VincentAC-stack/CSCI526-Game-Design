using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlNew : MonoBehaviour
{
    private GameObject laser;
    public static bool isAppear = false;

    void Start()
    {
        laser = GameObject.FindGameObjectWithTag("LaserWithParticleNew");
        laser.SetActive(isAppear);
        // Debug.Log("start"+ isAppear);
    }

    void Update()
    {

        if (isAppear)
        {
            laser.SetActive(true);
        }
        else if (!isAppear)
        {
            laser.SetActive(false);
        }

    }
}
