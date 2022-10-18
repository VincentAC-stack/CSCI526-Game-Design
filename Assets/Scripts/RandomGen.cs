using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;
using Task = System.Threading.Tasks.Task;

public class RandomGen: MonoBehaviour {
    public GameObject[] objects;
    public bool isPositionDynamic;
    public float xpos;
    public float ypos;
    private float update;
    private GameObject camera;
    private bool reverse;
    private int orderedIndex;
    private Vector3 dynamicPosition;

    void Start(){
        camera = GameObject.Find("Main Camera");
        reverse = false;
        orderedIndex = 0;

        // Keep the original game object. Otherwise may have missing reference exception.
        for (int i = 0; i < objects.Length; i++) {
            objects[i].SetActive(false);
        }

        if (isPositionDynamic) {
            dynamicPosition = new Vector3((float)(camera.transform.position.x + 3.6), ypos, 0);
        }
        else {
            dynamicPosition = new Vector3(xpos, ypos, 0);
        }
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.J)) {
            reverse = !reverse;
        }
        // Optimize the shooting position of the ball. Let the ball shoot from the left boundary of
        // camera view instead of the end of finished line.
        if (isPositionDynamic) {
            dynamicPosition = new Vector3((float)(camera.transform.position.x + 3.6), ypos, 0);
        }
        else {
            dynamicPosition = new Vector3(xpos, ypos, 0);
        }
        
        // This feature is to reverse the moving direction of the ball. The function is completed
        // but not open to public until further discussion.
        // Vector3 dynamicPosition = !reverse
        //     ? new Vector3((float)(camera.transform.position.x + 3.6), -1, 0)
        //     : new Vector3((float)(camera.transform.position.x - 3.6), -1, 0);

        update += Time.deltaTime;
        
        if (update > 3.0f) {
            update = 0.0f;
            
            if (orderedIndex >= objects.Length) {
                orderedIndex = 0;
            }

            // random index
            // int index = Random.Range(0, objects.Length);
            
            // ordered index
            int index = orderedIndex++;
            
            GameObject copy = Instantiate<GameObject>(objects[index], dynamicPosition, Quaternion.identity);
            copy.SetActive(true);
            
            // Instantiate(copy, fixedPosition, Quaternion.identity);
        }
    }
}
