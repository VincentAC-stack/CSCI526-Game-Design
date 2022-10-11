using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private GameObject plats;
    public static bool isAppear = false;
    
    // Start is called before the first frame update
    void Start()
    {
        plats = GameObject.Find("Plat");
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
            plats.GetComponent<MovingPlatformHorizontal>().enabled = false;
            // plats.SetActive(false);
            isAppear = false;
            
        }
        else if (!isAppear)
        {
            plats.GetComponent<MovingPlatformHorizontal>().enabled = true;
            // plats.SetActive(true);
            isAppear = true;
            
        }
        
    }
}
