using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileForPlayer : MonoBehaviour
{
    public float speed;

    private Transform player;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(player.forward.z);
        if (player.forward.z == 1)
        {
            isFacingRight = true;
        }
        else
        {
            isFacingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isFacingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collide: "+ other.gameObject.name);
        if (other.gameObject.name.Contains("Enemy"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
