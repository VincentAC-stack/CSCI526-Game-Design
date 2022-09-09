using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    public float followSpeed = 2.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = playerTransform.position; //transform.position是获取主相机的位置
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            targetPosition.x = Mathf.Clamp(playerTransform.position.x,minX,maxX);
            targetPosition.y = Mathf.Clamp(playerTransform.position.y,minY,maxY);
            transform.position = Vector2.Lerp(transform.position,targetPosition,followSpeed*Time.deltaTime);
        }
    }
}
