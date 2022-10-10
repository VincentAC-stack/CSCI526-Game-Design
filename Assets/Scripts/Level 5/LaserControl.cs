using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public static bool isAppear = true;

    void Start()
    {
        laser1 = GameObject.Find("LaserWithParticle1");
        laser2 = GameObject.Find("LaserWithParticle2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isAppear)
            {
                laser1.SetActive(false);
                laser2.SetActive(false);
                isAppear = false;
            }
            else if (!isAppear)
            {
                laser1.SetActive(true);
                laser2.SetActive(true);
                isAppear = true;
            }
        }
    }
}
