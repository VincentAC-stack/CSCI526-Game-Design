using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintControl : MonoBehaviour
{
    bool showtext;
    float currenttime;
    float timesincestart;
    TextMeshProUGUI tmptext;

    public float Delay;
    public float Disappear;
    public string HintText = "This is a sample Hint.";

    // Start is called before the first frame update
    void Start()
    {
        showtext = false;
        currenttime = Time.time;
        timesincestart = 0f;

        tmptext = gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        tmptext.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        timesincestart = (Time.time - currenttime);

 
         if(timesincestart >= Delay && timesincestart < Disappear)
         {
             showtext = true;
         } else if (timesincestart >= Disappear) {
            showtext = false;
         }

         if (showtext == true) {
            tmptext.text = HintText;
         } else {
            tmptext.text = "";
         }
    }
}
