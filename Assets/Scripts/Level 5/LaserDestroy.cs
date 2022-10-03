using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    public float timeTilDestroy;

    private void Update()
    {
        Destroy(gameObject, timeTilDestroy);
    }
}
