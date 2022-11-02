using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanParticleSwitch : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var main = _particleSystem.main;
            main.gravityModifierMultiplier *= -1;
        }
    }
}
