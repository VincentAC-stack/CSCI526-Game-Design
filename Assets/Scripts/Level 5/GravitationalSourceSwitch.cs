using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalSourceSwitch : MonoBehaviour
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
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && GameController.canMove )
        {
            _areaEffector2D.forceAngle = (_areaEffector2D.forceAngle + 180) % 360;
        }
    }
}
