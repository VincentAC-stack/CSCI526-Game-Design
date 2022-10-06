using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForceX = 10;
    public float jumpForceY = 10;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _animator.SetTrigger("jump");
            Rigidbody2D rigidbody2D = col.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
            // rigidbody2D.velocity += new Vector2(1, 0) * 10;
        }
    }
}
