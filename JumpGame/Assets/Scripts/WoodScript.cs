using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {
float countDown = 5.0f;

// Use this for initialization
void Start () {


}

// public Vector2 speed = new Vector2(5, 5);


void Update () {
    // float inputX = Input.GetAxis ("Horizontal");
    // Vector3 Vector3 = new Vector3(speed.x * inputX, 0, 0);

    countDown -= Time.deltaTime;

    if (countDown > 0.0f) {
    transform.position += new Vector3(0.8f * Time.deltaTime, 0 , 0);

}

    else if (countDown > -5.0f) {
        transform.position += new Vector3(-0.8f * Time.deltaTime, 0 , 0);
    // countDown += Time.deltaTime;
    }else{
      countDown = 5.0f;
    }
}
}
