using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 1.8f;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public GameObject ResetWindow;
    public GameObject ResetWindow_2;
    public GameObject FinishWindow;
    private bool isTouchingGround;
    private static int isDeath = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (transform.position.y < -6f)
        {
            if (isDeath == 0)
            {
                ResetWindow_2.SetActive(true);
                isDeath += 1;
            }
            else
            {
                ResetWindow.SetActive(true);
                isDeath += 1;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            float jumpVelocity = 5f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FinishFlag")
        {
            FinishWindow.SetActive(true);
        }
    }
}
