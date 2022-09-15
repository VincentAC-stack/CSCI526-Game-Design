using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private GameObject up;

    private GameObject low;
    
    private bool reversed = false;
    // Start is called before the first frame update
    void Start()
    {
        up = GameObject.Find("Upper");
        low = GameObject.Find("Lower");
        up.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // reversed = !reversed;
            
            Color32 upperColor = up.GetComponent<SpriteRenderer >().color;
            Color32 lowerColor = low.GetComponent<SpriteRenderer >().color;
            // print(upperColor);
            up.GetComponent<SpriteRenderer >().color = lowerColor;
            low.GetComponent<SpriteRenderer >().color = upperColor;
            // if (reversed)
            // {
            //     low.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
            //     // up.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            // }
            // else
            // {
            //     low.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            //     // up.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
            // }
        }
    }
}
