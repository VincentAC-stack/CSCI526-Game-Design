using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatforms : MonoBehaviour
{
    public static float edgey = 2.5f;
    public static float speed = 0.7f;
    public static float temp = 1f;

    void Start()
    {
        edgey = 2.5f;
        speed = 0.6f;
    }

    void Update()
    {
        temp -= Time.deltaTime;
        if (temp < -1f)
        {
            temp = 1f;
        }

        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;

            if (speed < 0f)
            {
                if (pos.y > -edgey)
                {
                    pos.y = edgey;
                }
            }
            else
            {
                if (pos.y < -edgey)
                {
                    pos.y = edgey;
                }
            }


            pos.y -= speed*Time.deltaTime;
            tran.position = pos;
        }

    }
}
