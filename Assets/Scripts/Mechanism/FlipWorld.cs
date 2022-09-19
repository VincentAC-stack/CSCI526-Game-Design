using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour
{
    private GameObject[] Ceilings;
    private GameObject[] Grounds;
    private bool Flipped = false;

    // public int Offset = 4;
    // Start is called before the first frame update
    void Start()
    {
        Ceilings = GameObject.FindGameObjectsWithTag("Ceiling");
        Grounds = GameObject.FindGameObjectsWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flip();
        }
    }

    void Flip()
    {
        for (int i = 0; i < Ceilings.Length; i++)
        {
            Vector3 pos = Ceilings[i].transform.position;
            pos.y = -pos.y;
            // if (!Flipped) 
            // else pos.y += Offset;
            Ceilings[i].transform.position = pos;
            float rotationZ = Ceilings[i].transform.eulerAngles.z;
            Ceilings[i].transform.rotation *= Quaternion.Euler(0, 180, rotationZ * 2);
            // Ceilings[i].transform.position.y -= 4;

        }
        for (int i = 0; i < Grounds.Length; i++)
        {
            Vector3 pos = Grounds[i].transform.position;
            pos.y = -pos.y;
            // if(!Flipped) pos.y += Offset;
            // else pos.y -= Offset;
            Grounds[i].transform.position = pos;
            float rotationZ = Grounds[i].transform.eulerAngles.z;
            Grounds[i].transform.rotation *= Quaternion.Euler(0, 180, rotationZ * 2);
        }
        Flipped = !Flipped;
    }
}
