using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.y = -playerPos.y;
        GameObject.FindGameObjectWithTag("ShadowPlayer").transform.position = playerPos;
        
        Quaternion playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        GameObject.FindGameObjectWithTag("ShadowPlayer").transform.rotation = playerRot * Quaternion.Euler(0, 180, 180);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.y = -playerPos.y;
        GameObject.FindGameObjectWithTag("ShadowPlayer").transform.position = playerPos;
        
        Quaternion playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        GameObject.FindGameObjectWithTag("ShadowPlayer").transform.rotation = playerRot * Quaternion.Euler(0, 180, 180);
    }
}
