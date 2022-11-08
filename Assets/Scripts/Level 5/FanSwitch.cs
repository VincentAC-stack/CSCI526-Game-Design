using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSwitch : MonoBehaviour
{
    private AreaEffector2D _areaEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        _areaEffector2D = GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.flipFan || Input.GetKeyDown(KeyCode.LeftShift))
        {
            _areaEffector2D.forceAngle = (_areaEffector2D.forceAngle + 180) % 360;
        }
    }

    private void LateUpdate(){
        GameController.flipFan = false;
    }
}
