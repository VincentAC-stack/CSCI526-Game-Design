using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPortal : MonoBehaviour
{
    public Transform RedOut;
    public Transform GreenOut;
    public Transform YellowOut;
    private GameObject Player;
    private Transform playerPos;
    public bool isTeleport = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        print(ColorMatch.currColor);
        if (isTeleport == false)
        {
            if (ColorMatch.currColor == "Red" && RedOut != null)
            {
                isTeleport = true;
                Player.gameObject.transform.position = RedOut.transform.position;
                
                if (Player.gameObject.transform.rotation.y == 0)
                {
                    Player.transform.position = RedOut.transform.position + new Vector3(0.35f, 0, 0);
                }
                else
                {
                    Player.transform.position = RedOut.transform.position + new Vector3(-0.35f, 0, 0);
                }
                StartCoroutine(TeleportCountDownRoutine());
            }
            else if (ColorMatch.currColor == "Green" && GreenOut != null){
                isTeleport = true;
                Player.gameObject.transform.position = RedOut.transform.position;
                
                if (Player.gameObject.transform.rotation.y == 0)
                {
                    Player.transform.position = GreenOut.transform.position + new Vector3(0.35f, 0, 0);
                }
                else
                {
                    Player.transform.position = GreenOut.transform.position + new Vector3(-0.35f, 0, 0);
                }
                StartCoroutine(TeleportCountDownRoutine());
            }
            else if (ColorMatch.currColor == "Yellow" && YellowOut != null)
            {
                isTeleport = true;
                Player.gameObject.transform.position = RedOut.transform.position;
                
                if (Player.gameObject.transform.rotation.y == 0)
                {
                    Player.transform.position = YellowOut.transform.position + new Vector3(0.35f, 0, 0);
                }
                else
                {
                    Player.transform.position = YellowOut.transform.position + new Vector3(-0.35f, 0, 0);
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
