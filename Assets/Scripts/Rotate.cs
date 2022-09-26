using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform tran in transform)
        {
            Quaternion pos = tran.rotation;
            
            float speedx = 0;
            float speedy = 0;



            pos.x -= speedx*Time.deltaTime;
            pos.y -= speedy*Time.deltaTime;
        }
    }
}

