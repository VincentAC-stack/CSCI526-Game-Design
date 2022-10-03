using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;


public class DiamondTrigger: MonoBehaviour
{
  public GameObject[] bullet;




  void OnTriggerEnter2D(Collider2D collision)

  {

       bullet = GameObject.FindGameObjectsWithTag("Bullet");

      if (collision.CompareTag("Player"))
      {
        if (bullet.Length != 0)
        {
            for (int i = 0; i < bullet.Length; i++)
            {
              bullet[i].GetComponent<Projectile>().ifPauseBullet = true;
            }
        }


      }

  }

}
