using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatingPlatforms : MonoBehaviour
{
    private float[] ABC;
    
    
    public static float rpm = -60f;
    private float radius = 1.5f;
    private float centerx = 16.8f;
    private float centery = 0f;
    
    
    void Start()
    {
        int i = 0;
        rpm = 60f;
        ABC = new float[transform.childCount];
        foreach (Transform tran in transform)
        {
            ABC[i] = (360 / transform.childCount) * i;
            tran.eulerAngles = new Vector3(
                tran.eulerAngles.x,
                tran.eulerAngles.y,
                ABC[i] + 30
            );
            i++;
        }
        
    }
    
    void Update()
    {
        int i = 0;
        foreach (Transform tran in transform)
        {
            
            Vector3 pos = tran.position;
            pos.x = centerx;
            pos.y = centery;
            
            ABC[i] += rpm * Time.deltaTime;
            Vector3 direction = Quaternion.AngleAxis(ABC[i], Vector3.forward) * Vector3.up;
            tran.Rotate(0f,0f, rpm/2 * Time.deltaTime);
            tran.position = pos + direction * radius;
            i++;
        }
        
    }
}
