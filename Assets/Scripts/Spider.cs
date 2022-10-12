using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
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

    public int maxHealthForSpider;

    public HealthBarBackup healthBarBackup;


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
        if(transform.position.y< -2.3)
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

    }

    void OnCollisionEnter2D(Collision2D collison){

      if(collison.gameObject.CompareTag("Player")){
        int curHealthForPlayer = player.gameObject.GetComponent<HealthBarForPlayer>().getCurrentHealth();
        player.gameObject.GetComponent<HealthBarForPlayer>().decreaseHealth(curHealthForPlayer/2);

        GameController.ifTriggerSpider = true;

      }
    }






}
