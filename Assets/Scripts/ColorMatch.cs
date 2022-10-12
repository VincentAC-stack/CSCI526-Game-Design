using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorMatch : MonoBehaviour
{
    
    private GameObject player;
    private GameObject currentPlatform;
    private GameObject[] platforms;
    private float distToGround;
    private SpriteRenderer playerSprite;
    public static string currColor;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public static bool isReversed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        currColor = "White";
        isReversed = false;
        platforms = GameObject.FindGameObjectsWithTag("RotateX");
        playerSprite = GetComponent<SpriteRenderer>();
    }
    
    /*
     * Detect the platform immediately as long as the player gets touch with it (The function
     * will be triggered when the state changes from untouched state to touched state).
     */
    void OnCollisionEnter2D(UnityEngine.Collision2D collision){
        // If player gets touch with platform or the ball, the collision happened.
        if (collision.gameObject.name.Contains("Platform") )
        {

            if (!collision.gameObject.name.Contains(currColor) && collision.gameObject.GetComponent<SpriteRenderer>().color != Color.white)
            {
                gameObject.GetComponent<HealthBarForPlayer>().decreaseHealth(20);
                // print(currHealth);
                // gameObject.GetComponent<HealthBarBackup>().SetHealth(0);
            }
        }
        //
        else if (collision.gameObject.name.Contains("StaticCircle"))
        {
            string temp = collision.gameObject.name.Substring(collision.gameObject.name.IndexOf('-') + 1);
            if (temp.IndexOf('(') == -1)
            {
                currColor = temp;
            }
            else
            {
                string ballColor = temp.Substring(0, temp.IndexOf('('));
                currColor = ballColor;
            }
            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name.Contains("Circle")){
            string temp = collision.gameObject.name.Substring(collision.gameObject.name.IndexOf('-') + 1);
            string ballColor = temp.Substring(0, temp.IndexOf('('));
            currColor = ballColor;
        }
       
    }
    
    /*
     *  Continuous detecting the platform where the player stands on as long as the player moves.
     */
    
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // print("isTouchingGround: " + isTouchingGround);

        if (Input.GetKeyDown(KeyCode.J)) {
            isReversed = !isReversed;
        }
    }
}
