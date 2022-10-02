using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectileForPlayer;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            //TODO: Recenter player
            Instantiate(projectileForPlayer, transform.GetComponent<Renderer>().bounds.center, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
