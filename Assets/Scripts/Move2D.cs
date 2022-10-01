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
    public TextMeshProUGUI DeathText;
    private Vector3 respawnPoint;
    
    // sending data to google form
    string URL = "https://docs.google.com/forms/d/e/1FAIpQLSd-S6YVYOZnN_6exc5vZ5VZo5YNYqJp_lvhJsBtB9ELpxqVrQ/formResponse";
    private long _sessionID;
    private string _levelName;
    private bool _gameResult;
    private int _totalDeathTime;

    private void Awake()
    {
        _sessionID = MenuManager._userId;
    }

        // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rigidbody2d = GetComponent<Rigidbody2D>();
        DeathText.text = "Death: " + GameController.deathCount;
        _levelName = SceneManager.GetActiveScene().name;
        respawnPoint = transform.position;
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
            // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            // transform.position += movement * Time.DeltaTime * moveSpeed;
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
        if (collision.gameObject.name == "FinishFlag")
        {
            GameController.canMove = false;
            GameController.GameFinish = true;
            _gameResult = true;
            _totalDeathTime = GameController.deathCount;
            Send();
        }
        else if (collision.gameObject.name == "DownFailChecker")
        {
            GameController.canMove = false;
            GameController.PlayerDead = true;
            GameController.deathCount += 1;
            DeathText.text = "Death: " + GameController.deathCount;
            _gameResult = false;
            _totalDeathTime = -1;
            Send();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    public void Send() 
    {
        StartCoroutine(Post(_levelName, _sessionID.ToString(), _gameResult.ToString(), _totalDeathTime.ToString()));
    }

    private IEnumerator Post(string _levelName, string _sessionID, string _gameResult, string _totalDeathTime)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.1179097589", _levelName);
        form.AddField("entry.1585400280", _sessionID);
        form.AddField("entry.199638597", _gameResult);
        form.AddField("entry.820838070", _totalDeathTime);
        
        // Send responses and verify result
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
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
