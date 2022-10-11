using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatforms2 : MonoBehaviour
{
    private float[] ABC;
    public static float edgey = 0;
    public static float speed = 0;
    public static float movement = 2f;
    public static float timer = 0f;

    void Start()
    {
        int i = 0;
        edgey = -2.5f;
        speed = -45f/48f;
        movement = 2f;
        timer = 0f;
        ABC = new float[transform.childCount];
        foreach (Transform tran in transform)
        {
            ABC[i] = 2.5f - (5f / transform.childCount) * i;
            
            Vector3 pos = tran.position;
            pos.y = ABC[i];
            tran.position = pos;
            i++;
        }
    }
    
    void Update()
    {
        if (timer > 0f)
        {
            timer -= 0.5f*Time.deltaTime;
            return;
        }
        if (movement > 0f)
        {
            movement -= 0.25f*Time.deltaTime;
        }
        else
        {
            movement += 2f;
            timer = 2f;
            return;
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
