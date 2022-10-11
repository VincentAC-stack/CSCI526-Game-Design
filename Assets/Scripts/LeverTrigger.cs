using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private GameObject[] plats;
    public static bool isAppear = false;
    
    // Start is called before the first frame update
    void Start()
    {
        plats = GameObject.FindGameObjectsWithTag("MovingPlat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collide!");
        Debug.Log(col.gameObject.tag);
     
        if (isAppear)
        {
            for (int i = 0; i < plats.Length; i++)
            {
                plats[i].GetComponent<MovingPlatformHorizontal>().enabled = false;
                // plats[i].SetActive(false);
                isAppear = false;
            }
        }
        else if (!isAppear)
        {
            for (int i = 0; i < plats.Length; i++)
            {
                plats[i].GetComponent<MovingPlatformHorizontal>().enabled = true;
                // plats[i].SetActive(true);
                isAppear = true;
            }
        }
        
    }
}
