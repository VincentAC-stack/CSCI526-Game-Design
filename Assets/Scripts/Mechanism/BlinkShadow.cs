using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkShadow : MonoBehaviour
{
    public GameObject ShadowHint;
    // Start is called before the first frame update
    void Start()
    {
        ShadowHint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ShadowPlayer")
        {
            ShadowHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShadowHint.SetActive(false);
    }
}
