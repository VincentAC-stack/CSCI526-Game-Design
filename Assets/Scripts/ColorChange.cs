using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private GameObject up;
    private GameObject low_1;
    private GameObject low_2;

    // private bool reversed = false;
    // Start is called before the first frame update
    void Start()
    {
        up = GameObject.Find("Upper");
        low_1 = GameObject.Find("Lower-1");
        low_2 = GameObject.Find("Lower-2");
        up.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Color32 upperColor = up.GetComponent<SpriteRenderer>().color;
            Color32 lowerColor_1 = low_1.GetComponent<SpriteRenderer>().color;
            Color32 lowerColor_2 = low_2.GetComponent<SpriteRenderer>().color;
            // print(upperColor);
            up.GetComponent<SpriteRenderer>().color = lowerColor_1;
            low_1.GetComponent<SpriteRenderer>().color = upperColor;
            low_2.GetComponent<SpriteRenderer>().color = upperColor;
        }
    }
}