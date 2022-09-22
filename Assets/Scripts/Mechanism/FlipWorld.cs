using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour
{
    private GameObject[] Ceilings;
    private GameObject[] Grounds;
    private GameObject[] Grass;
	private GameObject[] Portals;
    private bool Flipped = false;

    // public int Offset = 4;
    // Start is called before the first frame update
    void Start()
    {
        Ceilings = GameObject.FindGameObjectsWithTag("Ceiling");
        Grounds = GameObject.FindGameObjectsWithTag("Ground");
        Grass = GameObject.FindGameObjectsWithTag("grass");
 		Portals = GameObject.FindGameObjectsWithTag("Portal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
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
        for (int i = 0; i < Grass.Length; i++)
        {
            Vector3 pos = Grass[i].transform.position;
            pos.y = -pos.y;
            // if(!Flipped) pos.y += Offset;
            // else pos.y -= Offset;
            Grass[i].transform.position = pos;
            float rotationZ = Grass[i].transform.eulerAngles.z;
            Grass[i].transform.rotation *= Quaternion.Euler(180, 180, 0);
        }
 		for (int i = 0; i < Portals.Length; i++)
        {
            Vector3 pos = Portals[i].transform.position;
            pos.y = -pos.y;
            // if(!Flipped) pos.y += Offset;
            // else pos.y -= Offset;
            Portals[i].transform.position = pos;
            float rotationZ = Portals[i].transform.eulerAngles.z;
            Portals[i].transform.rotation *= Quaternion.Euler(180, 0, 0);
        }
        
        Flipped = !Flipped;
    }
}
