using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private Transform plats;
    private Transform lever;
    public bool isAppear = false;
    private GameObject MovingPlats;
    private bool canActivate = true;
    
    // Start is called before the first frame update
    void Start()
    {
        MovingPlats  = GameObject.Find("MovingPlats");
        Transform[] transforms = MovingPlats.GetComponentsInChildren<Transform>();
        foreach(Transform t in transforms)
        {
            // Debug.Log(t);
            if (t.gameObject.name == "TriggeredPlatform")
            {
                plats = t;
            }
            if (t.gameObject.name == "LeverTrigger")
            {
                lever = t;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        

        if (canActivate)
        {
            canActivate = false;
            Vector3 lTemp = lever.localScale;
            lTemp.y *= -1;
            lever.localScale = lTemp;
            if (isAppear )
            {
                plats.GetComponent<MovingPlatformHorizontal>().enabled = false;
                isAppear = false;
            }
            else if (!isAppear)
            {
                plats.GetComponent<MovingPlatformHorizontal>().enabled = true;
                isAppear = true;
            }
        }
        
        StartCoroutine(TriggerRoutine());
    }
    
    IEnumerator TriggerRoutine() {
        yield return new WaitForSeconds(0.5);
        canActivate = true;
    }
}

