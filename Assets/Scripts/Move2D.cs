using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject FirstTimeFailWindow;
    public GameObject FinishWindow;
    private bool isTouchingGround;
    public TextMeshProUGUI DeathText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        DeathText.text = "Death: " + Count.totalKill;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.canMove)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Jump();
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
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
        // this.SetActive(false);
        if (collision.gameObject.name == "FinishFlag")
        {
            GameController.canMove = false;
            FinishWindow.SetActive(true);
        }
        else if (collision.gameObject.name == "FirstTimeFailChecker")
        {
            GameController.canMove = false;
            FirstTimeFailWindow.SetActive(true);
            Count.totalKill += 1;
            DeathText.text = "Death: " + Count.totalKill;
        }
        else if (collision.gameObject.name == "DownFailChecker")
        {
            GameController.canMove = false;
            ResetWindow.SetActive(true);
            Count.totalKill += 1;
            DeathText.text = "Death: " + Count.totalKill;
        }
    }
}
