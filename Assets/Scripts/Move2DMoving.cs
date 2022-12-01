using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Move2DMoving : MonoBehaviour
{
    private Rigidbody2D rbody;

    private bool isOnPlatform;

    private Rigidbody2D platformRBody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name.Contains("SmallPlatform"))
        {
            Debug.Log("find moving platform");
            platformRBody = col.gameObject.GetComponent<Rigidbody2D>();
Debug.Log(platformRBody.velocity);
            isOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("SmallPlatform"))
        {
            isOnPlatform = false;
            platformRBody = null;
        }
    }

    void FixedUpdate()
    {
        if (isOnPlatform)
        {
            
            rbody.velocity = rbody.velocity + platformRBody.velocity;
        }
    }

}