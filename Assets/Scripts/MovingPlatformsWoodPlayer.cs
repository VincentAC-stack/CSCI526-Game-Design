using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatformsWoodPlayer : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    public Transform playerDefTransform;

    private int i;
    private bool moving;
    private void Start()
    {
        transform.position = points[startingPoint].position;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.parent = gameObject.transform;
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = playerDefTransform;
    }
}
