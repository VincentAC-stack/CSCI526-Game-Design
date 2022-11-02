using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{

    public GameObject projectileForPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(projectileForPlayer, transform.GetComponent<Renderer>().bounds.center, Quaternion.identity);
    }
}
