using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    //Speed
    public float Speed = 2f;
    //要随机的地面数组
    public GameObject[] GroundPrefabs;

    // Update is called once per frame
    void Update()
    {
        //Traverse ground
        foreach (Transform tran in transform)
        {
            //Get current position of tran
            Vector3 pos = tran.position;
            pos.x -= Speed * Time.deltaTime;

            if (pos.x < -7.2f)
            {
                //创建新的地面
                // Transform newTrans = Instantiate(GroundPrefabs[Random.Range(0, GroundPrefabs.Length)],transform).transform;
                pos.x += 7.2f * 2; 
            } 
            tran.position = pos;
        }
    }
}
