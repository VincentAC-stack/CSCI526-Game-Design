using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionTrigger : MonoBehaviour
{
    
    private GameObject player;
    private GameObject currentPlatform;
    private GameObject[] platforms;
    private float distToGround;
    private SpriteRenderer playerSprite;
    // public TextMeshProUGUI DeathText;
    
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public static bool isReversed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        isReversed = false;
        platforms = GameObject.FindGameObjectsWithTag("RotateX");
        playerSprite = GetComponent<SpriteRenderer>();
        // DeathText.text = "Death: " + Count.totalKill;
        // print("Start() DeathText: " + Count.totalKill);
        // print(DeathText == null);
    }
    
    /*
     * Detect the platform immediately as long as the player gets touch with it (The function
     * will be triggered when the state changes from untouched state to touched state).
     */
    void OnCollisionEnter2D(UnityEngine.Collision2D collision){
        // If player gets touch with platform or the ball, the collision happened.
        if (collision.gameObject.CompareTag("RotateX")) {
            currentPlatform = collision.gameObject;
        }
        
        if (collision.gameObject.CompareTag("RotateX") || (collision.gameObject.CompareTag("Ball") && isTouchingGround)) {
            SpriteRenderer platformSpriteRenderer = currentPlatform.GetComponent<SpriteRenderer>();
            if (platformSpriteRenderer.color != playerSprite.color) {
                // Color doesn't match. Game Over.
                // print("Color does NOT match!");
                // print("platform color: " + platformSpriteRenderer.color);
                // print("player color: " + playerSprite.color);
                GameController.canMove = false;
                GameController.PlayerDead = true;
                
                // Count.totalKill += 1;
                
                // DeathText.text = "Death: " + Count.totalKill;
                // print("Count.totalKill " + Count.totalKill);
            }
            else {
                // print("Color match!");
            }
        }
    }
    
    /*
     *  Continuous detecting the platform where the player stands on as long as the player moves.
     */
    void OnCollisionStay2D(Collision2D collision){
        // print("There is a collision: " + collision.gameObject.name);
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // print("isTouchingGround: " + isTouchingGround);

        if (Input.GetKeyDown(KeyCode.J)) {
            isReversed = !isReversed;
        }
    }
}
