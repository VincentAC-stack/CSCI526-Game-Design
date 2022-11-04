using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderL : MonoBehaviour
{
    public float speed;

    // public float stoppingDistance;
    // public float retreatDistance;

    // private float timeBtwShots;
    // public float startTimeBtwShots;

    // public GameObject projectile;
    public Transform player;

    public int healthForSpider;
    public int damageFromPlayer;
    public int damage;

    public int maxHealthForSpider;

    // public GameObject SpiderWindow;

    public HealthBarBackup healthBarBackup;
    // public Rigidbody2D rigidbody2d;

    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;

    public bool mustPatrol;
    public Rigidbody2D rb;
    public float walkSpeed;

    private bool mustTurn;

    //private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {

        mustPatrol = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthForSpider = maxHealthForSpider;
        healthBarBackup.SetMaxHealth(maxHealthForSpider);
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol){
          patrol();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(180f, 0f, 0f, Space.Self);
        }

        if (transform.position.y < -2.1)
        {
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate(){

      if(mustPatrol){
        mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
      }
    }

    void patrol(){
      if(mustTurn || bodyCollider.IsTouchingLayers(wallLayer)){
        Flip();
      }

      rb.velocity = new Vector2(walkSpeed, rb.velocity.y);

    }

    void Flip(){
      mustPatrol = false;
      transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y );
      walkSpeed *= -1;

          mustPatrol = true;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("BulletForPlayer"))
        {
            healthForSpider = healthForSpider - damageFromPlayer;
            healthBarBackup.SetHealth(healthForSpider);
        }
        if (healthForSpider <= 0)
        {

            Destroy(this.gameObject);

        }

    }

    void OnCollisionEnter2D(Collision2D collison)
    {

        if (collison.gameObject.CompareTag("Player"))
        {

            player.gameObject.GetComponent<HealthBarForPlayer>().decreaseHealth(damage);

            int playerHealth = player.gameObject.GetComponent<HealthBarForPlayer>().getCurrentHealth();

            if (playerHealth <= 0)
            {
                // SpiderWindow.SetActive(true);
                GameController.canMove = false;
            }
        }

        if (collison.gameObject.name.Contains("Laser"))
        {
            Flip();
        }
    }

}
