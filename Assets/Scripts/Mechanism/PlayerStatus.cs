using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static Vector3 respawnPos;
    public static int currHealth;
    public static int maxHealth = 100;
    
    private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("AstroStay");
        respawnPos = Player.transform.position;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // if (currHealth == 0)
        // {
        //     GameController.PlayerDead = true;
        // }
    }

    public void resetHealth()
    {
        currHealth = maxHealth;
    }
}
