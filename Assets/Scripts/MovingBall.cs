using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall: MonoBehaviour {
    private static string PLAYER_NAME = "AstroStay";
    private float horizontal;
    public float speed = 1f;
    public float destroyTime = 10;
    private SpriteRenderer ballSprite;

    void Start(){
        ballSprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
        // Speed & Position Control
        horizontal = Input.GetAxis("Horizontal");
        horizontal = speed * Time.deltaTime;
        transform.Translate(new Vector3(-horizontal, 0f, 0f));
        // This feature is to reverse the moving direction of the ball. The function is completed
        // but not open to public until further discussion.
        // transform.Translate(new Vector3(!CollisionTrigger.isReversed ? -horizontal : horizontal, 0f, 0f));

        // Destroy Control
        if (transform.position.x < -6 || transform.position.x > 25) {
            Destroy(gameObject);
        }
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
