using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private UnityEngine.Collision2D colli = null;
    private bool collided;
    void Start()
    {
        player = GameObject.Find("player");
    }
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision){
        // collided =true;
        colli = collision;
    }

    // public void OnCollisionExit2D(UnityEngine.Collision2D collision)
    // {
    //     collided = false;
    // }

    void Update()
    {
        if (colli != null)
        {
            Color32 currColor = colli.gameObject.GetComponent<SpriteRenderer >().color;
            player.GetComponent<SpriteRenderer>().color = currColor;
        }
        
    }
}
