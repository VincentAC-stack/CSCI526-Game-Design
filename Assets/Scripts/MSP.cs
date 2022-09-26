using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;






public class MSP : MonoBehaviour
{
    public static float upperedgex = 6.0f;
    public static float loweredgex = -0.5f;
    public static float upperedgey = 0.8f;
    public static float loweredgey = -2.5f;

    void Start()
    {
        upperedgex = 6.0f;
        loweredgex = -0.5f;
        upperedgey = 0.8f;
        loweredgey = -2.5f;
    }
    
    void Update()
    {
        
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            
            float speedx = 0;
            float speedy = 0;
            
            float speedd = 0.7f;
            var rand = new System.Random();

            int temp = 0;
            
            if (pos.x < loweredgex)
            {
                if (pos.y > upperedgey){
                    temp = 1;
                }
                else if (pos.y < loweredgey){
                    temp = 4;
                }
                else{
                    temp = 1;
                }
            }
            
            else if (pos.x > upperedgex)
            {
                if (pos.y > upperedgey){
                    temp = 3;
                }
                else if (pos.y < loweredgey){
                    temp = 2;
                }
                else{
                    temp = 2;
                }
            }
            
            else
            {
                if (pos.y > upperedgey){
                    temp = 3;
                }
                else if (pos.y < loweredgey){
                    temp = 4;
                }
            }

            if (temp == 1)
            {
                speedx = 0;
                speedy = speedd;
            }
            else if (temp == 2)
            {
                speedx = 0;
                speedy = -speedd;
            }
            else if (temp == 3)
            {
                speedx = speedd;
                speedy = 0;
            }
            else
            {
                speedx = - speedd;
                speedy = 0;
            }
            


            pos.x -= speedx*Time.deltaTime;
            pos.y -= speedy*Time.deltaTime;
            tran.position = pos;
        }
        
    }
}
