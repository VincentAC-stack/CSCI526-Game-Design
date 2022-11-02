using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    //private Vector2 monsterMoveDirection;
    private float moveSpeed;
    //public Rigidbody2D rb;

    private void OnEnable()
    {
        Invoke("Destroy", 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //rb.velocity = monsterMoveDirection;
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    /*public void SetMonsterMoveDirection(Vector2 dir)
    {
        Debug.Log(dir);
        monsterMoveDirection = dir;
    }*/

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void onDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("SpiderMan") && !other.gameObject.name.Contains("Bullet"))
        {
            Destroy();
        }
    }
}
