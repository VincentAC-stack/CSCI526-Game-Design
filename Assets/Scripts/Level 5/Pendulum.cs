using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody2D rgb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    private bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        rgb2d.angularVelocity = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightAngle 
            && (rgb2d.angularVelocity > 0) 
            && rgb2d.angularVelocity < moveSpeed)
        {
            rgb2d.angularVelocity = moveSpeed;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftAngle 
                 && (rgb2d.angularVelocity < 0) 
                 && rgb2d.angularVelocity > moveSpeed * -1)
        {
            rgb2d.angularVelocity = moveSpeed * -1;
        }
    }
}
