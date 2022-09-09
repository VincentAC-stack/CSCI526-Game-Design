using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        // Application.targetFrameRate = 10;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");
        Vector3 position = transform.position;
        position.x = position.x + horizontal * 10f * Time.deltaTime;
        position.y = position.y + vetical * 10f * Time.deltaTime;
        // transform.position = position;
        rigidbody2D.MovePosition(position);
    }
}
