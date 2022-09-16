using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeB : MonoBehaviour
{
    private GameObject up_1;
    private GameObject up_2;
    private GameObject low;

    // private bool reversed = false;
    // Start is called before the first frame update
    void Start()
    {
        up_1 = GameObject.Find("Upper-1");
        up_2 = GameObject.Find("Upper-2");
        low = GameObject.Find("Lower");
        up_1.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
        up_2.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Color32 upperColor_1 = up_1.GetComponent<SpriteRenderer>().color;
            Color32 upperColor_2 = up_2.GetComponent<SpriteRenderer>().color;
            Color32 lowerColor = low.GetComponent<SpriteRenderer>().color;
            // print(upperColor);
            up_1.GetComponent<SpriteRenderer>().color = lowerColor;
            up_2.GetComponent<SpriteRenderer>().color = lowerColor;
            low.GetComponent<SpriteRenderer>().color = upperColor_1;
        }
    }
}