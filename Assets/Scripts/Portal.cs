using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform goToPos;
    private Transform playerTransform;
    public bool isTeleport = false;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.name.Contains("Bullet")){
          if (isTeleport == false)
          {
              isTeleport = true;
              if (playerTransform.rotation.y == 0)
              {
                  playerTransform.transform.position = goToPos.transform.position + new Vector3(0.35f, 0, 0);
              }
              else
              {
                  playerTransform.transform.position = goToPos.transform.position + new Vector3(-0.35f, 0, 0);
              }
              StartCoroutine(TeleportCountDownRoutine());
          }
        }


    }

    IEnumerator TeleportCountDownRoutine() {
        yield return new WaitForSeconds(4);
        isTeleport = false;
    }
}
