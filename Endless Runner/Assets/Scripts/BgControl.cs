using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //Speed
    public float Speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //Traverse background
        foreach (Transform tran in transform)
        {
            //Get current position of tran
            Vector3 pos = tran.position;
            pos.x -= Speed * Time.deltaTime;

            if (pos.x < -7.2f)
            {
                pos.x += 7.2f * 2; 
            } 
            tran.position = pos;
        }
    }
}
