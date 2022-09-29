using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float bulletTimeScale = 0.1f;
    private float defaultTimeScale = 1f;

    private float defaultFiexedDeltaTime;

    private bool isSlowed = false;

    void Start()
    {
        defaultFiexedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isSlowed)
            {
                Time.timeScale = bulletTimeScale;
                Time.fixedDeltaTime = defaultFiexedDeltaTime * Time.timeScale;
            }
            else
            {
                Time.timeScale = defaultTimeScale;
                Time.fixedDeltaTime = defaultFiexedDeltaTime * Time.timeScale;
            }

            isSlowed = !isSlowed;
        }
    }
    
    
}
