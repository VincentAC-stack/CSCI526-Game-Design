using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBall : MonoBehaviour {
    private static string PLAYER_NAME = "AstroStay";
    private float horizontal;
    private SpriteRenderer ballSprite;
    
    void Start(){
        ballSprite = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        // print("There is a collision: " + collision.gameObject.name);
        // print("The color is: " + ballSprite.color);
        if (collision.gameObject.name == PLAYER_NAME) {
            // Set the player color same with the ball's color
            GameObject player = collision.gameObject;
            SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            playerSpriteRenderer.color = ballSprite.color;
            
            Destroy(gameObject);
        }
    }
}