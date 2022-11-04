using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovingPlatformsWood : MonoBehaviour
{

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Use this for initialization
    void Start () {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

     // Update is called once per frame
     void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && GameController.canMove)
        {
            if(childTransform != null)
            {
                childTransform.rotation *= Quaternion.Euler(180, 0, 0);
            }

            Vector3 pos = childTransform.position;
            pos.y = -pos.y;
            childTransform.position = pos;
        }
        else
        {
            move();
        }
     }

     private void move(){
        if(childTransform != null)
        {
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
            if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1){
                ChangeDestination();
            }
        }
     }

     private void ChangeDestination(){
        nexPos = nexPos != posA ? posA : posB;
     }


 }
