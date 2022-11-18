using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotByClicking : MonoBehaviour
{
    public float speed;

    private Transform player;
    public Rigidbody2D bulletInstance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(player.forward.z);
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        if(shootDirection.x > 0)
        {
            player.forward = new Vector3(0f, 0f, 1f);
        }
        else
        {
            player.forward = new Vector3(0f, 0f, -1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*if (isFacingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }*/

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("trigger enter: "+ other.gameObject.name);
        if (!other.CompareTag("Player"))
        {
            if (!other.gameObject.name.Contains("Bullet"))
            {

                if (!other.CompareTag("FanParticle"))
                {

                    if (!other.gameObject.name.Contains("Portal"))
                    {

                        if (other.gameObject.name.Contains("Platform"))
                        {
                            DestroyProjectile();
                        }
                        else if (other.gameObject.name.Contains("Enemy"))
                        {
                            DestroyProjectile();

                        }
                        else if (other.gameObject.name.Contains("SpiderMan"))
                        {
                            DestroyProjectile();
                        }
                    }


                }

            }

        }

    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
