using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;


public class DiamondTrigger: MonoBehaviour
{
  public GameObject[] rotateX;




  void OnTriggerEnter2D(Collider2D collision)

  {

       rotateX = GameObject.FindGameObjectsWithTag("RotateX");

      if (collision.CompareTag("Player"))
      {
        if (rotateX.Length != 0)
        {
            for (int i = 0; i < rotateX.Length; i++)
            {
                    if(rotateX[i].name=="Bullet(Clone)"){
                      Destroy(rotateX[i]);

                    }
                    //bullet[i].GetComponent<Projectile>().ifPauseBullet = true;
            }
            Destroy(gameObject);

        }


      }

  }

}
