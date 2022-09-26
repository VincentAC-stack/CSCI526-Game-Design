using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;






public class RSP : MonoBehaviour
{
    private float angle = 0;
    void Update()
    {
        
        foreach (Transform tran in transform)
        {
            int rpm = 60;
            tran.Rotate(0f,0f, (30f) * Time.deltaTime);
            Vector3 pos = tran.position;
            pos.x = 17.2f;
            pos.y = 0.7f;
            angle += 30f * Time.deltaTime;
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
            tran.position = pos + direction * 1;
        }
        
    }
}
