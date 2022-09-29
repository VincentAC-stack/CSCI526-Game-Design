using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;
using Task = System.Threading.Tasks.Task;

public class RandomGen: MonoBehaviour {
    public GameObject[] objects;
    private float update;
    private GameObject camera;

    void Start(){
        // Keep the original game object. Otherwise may have missing reference exception.
        for (int i = 0; i < objects.Length; i++) {
            objects[i].SetActive(false);
        }
        
        camera = GameObject.Find("Main Camera");
    }
    
    void Update(){
        // Optimize the shooting position of the ball. Let the ball shoot from the left boundary of
        // camera view instead of the end of finished line.
        Vector3 dynamicPosition = new Vector3((float) (camera.transform.position.x + 3.6), -1, 0);
        
        update += Time.deltaTime;
        
        if (update > 3.0f) {
            update = 0.0f;
            
            int randomIndex = Random.Range(0, objects.Length);
            
            GameObject copy = Instantiate<GameObject>(objects[randomIndex], dynamicPosition, Quaternion.identity);
            copy.SetActive(true);
            
            // Instantiate(copy, fixedPosition, Quaternion.identity);
        }
    }
}
