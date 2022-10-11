using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    public int healthForEnemy;
    public int damageFromPlayer;
    public int maxHealthForEnemy;

    //private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //target = new Vector2(player.position.x, transform.position.y);
        /*if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }*/

        if (timeBtwShots <= 0 && transform.position.y - player.position.y > 0.5 && Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("BulletForPlayer"))
        {
            healthForEnemy = healthForEnemy - damageFromPlayer;
        }

        if (healthForEnemy <= 0)
        {
            // Application.LoadLevel("Death");
            player.gameObject.GetComponent<HealthBarForPlayer>().addHealth(maxHealthForEnemy);
            Destroy(this.gameObject);
            // GameController.canMove = false;
            // GameController.PlayerDead = true;
            // GameController.deathCount += 1;
        }
    }
}
