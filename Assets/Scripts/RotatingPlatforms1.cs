using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatingPlatforms1 : MonoBehaviour
{
    
    
    private float[] ABC;
    public static float dr = 1;
    public static float movement = 2f;
    public static float timer = 0f;
    
    
    void Start()
    {
        int i = 0;
        movement = 2f;
        timer = 0f;
        dr = 1;
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
        int i = 0;
        if (timer > 0f)
        {
            timer -= 1.5f*Time.deltaTime;
            return;
        }
        if (movement > 0f)
        {
            movement -= 0.75f*Time.deltaTime;
        }
        else
        {
            movement += 2f;
            timer = 2f;
        }
        foreach (Transform tran in transform)
        {
            
            tran.Rotate(0f,0f, dr * 90 * 3f/8f * Time.deltaTime);
            i++;
        }
        
    }
}
