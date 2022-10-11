using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatformHorizontal : MonoBehaviour
{
    public static float edgey;
    public static float edgey2;
    public static float speed = 0.7f;
    public static float originX;
    public static float range = 0.5f;
    
    void Start()
    {
       
        originX = transform.position.x;
        edgey = originX - range;
        edgey2 = originX + range;
    }
    
    void Update()
    {
        Vector3 pos = transform.position;
        if (speed < 0f)
        {
            if (pos.x > edgey2)
            {
                pos.x = edgey2;
                speed = -speed;
            }
        }
        else
        {
            if (pos.x < edgey)
            {
                pos.x = edgey;
                speed = -speed;
            }
        }
        pos.x -= speed*Time.deltaTime;
        transform.position = pos;
    }
}

