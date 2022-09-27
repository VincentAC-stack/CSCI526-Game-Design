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

    void Start(){
        // Keep the original game object. Otherwise may have missing reference exception.
        for (int i = 0; i < objects.Length; i++) {
            objects[i].SetActive(false);
        }
    }
    
    void Update(){
        update += Time.deltaTime;
        
        if (update > 3.0f) {
            update = 0.0f;
            
            int randomIndex = Random.Range(0, objects.Length);
            
            // The shooting position of the ball
            Vector3 fixedPosition = new Vector3(20, -1, 0);

            GameObject copy = Instantiate<GameObject>(objects[randomIndex]);
            copy.SetActive(true);
            
            // Instantiate(copy, fixedPosition, Quaternion.identity);
        }
    }
}
