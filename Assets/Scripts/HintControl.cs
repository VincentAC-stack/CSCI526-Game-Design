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
        if(Delay > timesincestart && showtext == false)
         {
             timesincestart += Time.time;
         }
 
         if(timesincestart >= Delay)
         {
             showtext = true;
         }

         if (showtext == true) {
            tmptext.text = HintText;
         }
    }
}
