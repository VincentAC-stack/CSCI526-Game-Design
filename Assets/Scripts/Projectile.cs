using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public bool ifPauseBullet;

    // Start is called before the first frame update
    void Start()
    {
        ifPauseBullet = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(!ifPauseBullet){
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        if (transform.position == player.position)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Enemy"))
        {
        if(!other.gameObject.name.Contains("BulletForPlayer") ){

          DestroyProjectile();
        }



        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
