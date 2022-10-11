using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPortal : MonoBehaviour
{
    public Transform RedOut;
    public Transform BlueOut;
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
        print((ColorMatch.currColor));
        if (ColorMatch.currColor == "Red")
        {
            isTeleport = true;
            Player.gameObject.transform.position = RedOut.transform.position;
            StartCoroutine(TeleportCountDownRoutine());
        }
        else if (ColorMatch.currColor == "Blue"){
            isTeleport = true;
            Player.gameObject.transform.position = BlueOut.transform.position;
            StartCoroutine(TeleportCountDownRoutine());
        }
        else if (ColorMatch.currColor == "Yellow")
        {
            isTeleport = true;
            Player.gameObject.transform.position = YellowOut.transform.position;
            StartCoroutine(TeleportCountDownRoutine());
        }
    }
    
    IEnumerator TeleportCountDownRoutine() {
        yield return new WaitForSeconds(1);
        isTeleport = false;
    }
}
