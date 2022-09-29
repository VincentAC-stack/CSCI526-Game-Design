using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdkW4EOt3GEJNMO_oLjj24GmgM38inU6tfZ9DDhJ36f-nDA3w/formResponse";
    string _gameResult = "RRRR";


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
            transform.position += movement * Time.unscaledDeltaTime * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            float jumpVelocity = 5f;
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
            Send();
        }
        else if (collision.gameObject.name == "DownFailChecker")
        {
            GameController.canMove = false;
            GameController.PlayerDead = true;
            Count.totalKill += 1;
            DeathText.text = "Death: " + Count.totalKill;
            Send();
        }
    }
    public void Send() 
    {
        StartCoroutine(Post(_gameResult));
    }

    private IEnumerator Post(string _gameResult)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm(); 
        form.AddField("entry.617275958", _gameResult); 
        // Send responses and verify result
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
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
