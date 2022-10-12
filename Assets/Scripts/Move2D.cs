using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 1.8f;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    
    private void Awake()
    {
        Data.SessionID = MenuManager._userId;
        Data.FlipCounts = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rigidbody2d = GetComponent<Rigidbody2D>();
        Data.LevelName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.canMove)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Jump();
            float xInput = Input.GetAxis("Horizontal");
            rigidbody2d.velocity = new Vector2(xInput * moveSpeed, rigidbody2d.velocity.y);
            // rigidbody2d.AddForce(new Vector2(xInput * moveSpeed, 0), ForceMode2D.Force);
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            // transform.position += movement * Time.DeltaTime * moveSpeed;
            if (movement != Vector3.zero)
            {
                transform.forward = new Vector3(0f, 0f, movement.x);
            }

        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            float jumpVelocity = 5.3f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            if (Time.timeScale != 1f)
            {
                rigidbody2d.gravityScale = 3f;
            }
            else
            {
                rigidbody2d.gravityScale = 1f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // this.SetActive(false);
        
        if (collision.gameObject.name == "DownFailChecker" || collision.gameObject.name == "DownFailChecker2") 
        {
            GameController.canMove = false;
            GameController.PlayerDead = true;
            PlayerStatus.currHealth = 0;
            Data.GameResult = false;
            Data.LevelDeaths = -1;
            Send();
        }
 
        // else if (collision.gameObject.name.Contains("Spike")  || collision.gameObject.name.Contains("Saw"))
        // {
        //     PlayerStatus.currHealth--;
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FinishFlag")
        {
            GameController.canMove = false;
            GameController.GameFinish = true;
            Data.GameResult = true;
            Data.LevelDeaths++;
            Send();
            Data.LevelDeaths = 0;
        }
        if (collision.gameObject.name == "Checkpoint")
        {
            PlayerStatus.respawnPos = collision.transform.position;
        }

        if (collision.gameObject.name.Contains("Bullet"))
        {
            PlayerStatus.currHealth--;
        }
    }

    public void Send()
    {
        StartCoroutine(Post(Data.LevelName, Data.SessionID.ToString(), Data.GameResult.ToString(), 
            Data.LevelDeaths.ToString(), Data.FlipCounts.ToString()));
    }

    private IEnumerator Post(string _levelName, string _sessionID, string _gameResult, string _totalDeathTime, string _flipTimes)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.1179097589", _levelName);
        form.AddField("entry.1585400280", _sessionID);
        form.AddField("entry.199638597", _gameResult);
        form.AddField("entry.820838070", _totalDeathTime);
        form.AddField("entry.2003297119", _flipTimes);

        // Send responses and verify result
        UnityWebRequest www = UnityWebRequest.Post(Data.URL, form);
        yield return www.SendWebRequest();
        www.Dispose();
        // using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) 
        // {
        //     yield return www.SendWebRequest();
        //     if (www.result != UnityWebRequest.Result.Success) {
        //         Debug.Log(www.error); }
        //     else{
        //         Debug.Log("Form upload complete!");} 
        // }
    }
}