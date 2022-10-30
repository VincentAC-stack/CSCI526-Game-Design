using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed;
    float countDown = 1.5f;
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

    public GameObject SpiderWindow;

    public HealthBarBackup healthBarBackup;
    public Rigidbody2D rigidbody2d;

    //private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // timeBtwShots = startTimeBtwShots;
        healthForSpider = maxHealthForSpider;
        healthBarBackup.SetMaxHealth(maxHealthForSpider);
    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody2d.AddForce(new Vector2(xInput * moveSpeed, 0), ForceMode2D.Force);
        Vector3 movement = new Vector3(0.8f * Time.deltaTime, 0f, 0f);
        // transform.position += movement * Time.DeltaTime * moveSpeed;
        countDown -= Time.deltaTime;

        if (countDown > 0.0f)
        {
            rigidbody2d.velocity = new Vector2(1.8f, 0);
            //rigidbody2d.AddForce(new Vector2(0.04f, 0), ForceMode2D.Impulse);
            transform.forward = new Vector3(0f, 0f, movement.x);
        }
        else if (countDown > -1.5f)
        {
            rigidbody2d.velocity = new Vector2(-1.8f, 0);
            //rigidbody2d.AddForce(new Vector2(-0.04f, 0), ForceMode2D.Impulse);
            transform.forward = new Vector3(0f, 0f, -movement.x);
        }
        else
        {
            countDown = 1.5f;
        }

      if (Input.GetKeyDown(KeyCode.C)){
        SpiderWindow.SetActive(false);
        GameController.canMove = true;
      }

      if (Input.GetKeyDown(KeyCode.J))
        {
            transform.Rotate(180f, 0f, 0f, Space.Self);
        }

        if (transform.position.y< -2.1)
        {
            Destroy(this.gameObject);
        }

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

    void OnCollisionEnter2D(Collision2D collison){



      if(collison.gameObject.CompareTag("Player")){

        player.gameObject.GetComponent<HealthBarForPlayer>().decreaseHealth(damage);

        int playerHealth = player.gameObject.GetComponent<HealthBarForPlayer>().getCurrentHealth();

        if(playerHealth > 0){
          SpiderWindow.SetActive(true);
          GameController.canMove = false;
        }




      }

    }



}
