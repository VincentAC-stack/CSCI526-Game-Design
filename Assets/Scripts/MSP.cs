using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MSP : MonoBehaviour
{

    void Update()
    {
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            float upperedgex = 3.5f;
            float loweredgex = 0.5f;
            float upperedgey = 0.8f;
            float loweredgey = 2.5f;
            
            float speedx = 0;
            float speedy = 0;
            
            float speedd = 1.4f;
            var rand = new System.Random();
            double scaled = (rand.NextDouble()*10f) + 0.75f;
            print(tran.speed);
            if (pos.x < -loweredgex)
            {
                if (pos.y > upperedgey){
                    speedd = (float)scaled;
                    speedx = 0;
                    speedy = speedd;
                }
                else if (pos.y < -loweredgey){
                    speedd = (float)scaled;
                    speedx = - speedd;
                    speedy = 0;
                }
                else{
                    speedx = 0;
                    speedy = speedd;
                }
            }
            else if (pos.x > upperedgex)
            {
                if (pos.y > upperedgey){
                    speedd = (float)scaled;
                    speedx = speedd;
                    speedy = 0;
                }
                else if (pos.y < -loweredgey){
                    speedd = (float)scaled;
                    speedx = 0;
                    speedy = -speedd;
                }
                else{
                    speedx = 0;
                    speedy = -speedd;
                }
            }
            else
            {
                if (pos.y > upperedgey){
                    speedx = speedd;
                    speedy = 0;
                }
                else if (pos.y < -loweredgey){
                    speedx = -speedd;
                    speedy = 0;
                }
            }
            


            pos.x -= speedx*Time.deltaTime;
            pos.y -= speedy*Time.deltaTime;
            tran.position = pos;
        }
        
    }
}
