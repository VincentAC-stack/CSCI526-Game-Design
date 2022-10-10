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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.y = -playerPos.y;
        GameObject.FindGameObjectWithTag("ShadowPlayer").transform.position = playerPos;
    }
}
