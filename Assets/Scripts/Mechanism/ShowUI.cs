using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiGuide;
    // Start is called before the first frame update
    void Start()
    {
        uiGuide.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiGuide.SetActive(true);
        }
    }
}
