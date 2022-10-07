using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

public class FlipWorld : MonoBehaviour
{
    private GameObject[] RotateXArr;
    private GameObject[] RotateXAndYArr;

    void Start()
    {
        RotateXArr = GameObject.FindGameObjectsWithTag("RotateX");
        RotateXAndYArr = GameObject.FindGameObjectsWithTag("RotateXAndY");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && GameController.canMove)
        {
            Data.FlipCounts++;
            Flip();
        }
    }
    void FlipY(GameObject obj)
    {
      if(obj != null){
        Vector3 pos = obj.transform.position;
        pos.y = -pos.y;
        obj.transform.position = pos;
      }

    }
    void RotateX(GameObject obj)
    {
      if(obj != null){
        obj.transform.rotation *= Quaternion.Euler(180, 0, 0);
      }

    }
    void RotateY(GameObject obj)
    {
        obj.transform.rotation *= Quaternion.Euler(0, 180, 0);
    }

    void RotateXAndY(GameObject obj)
    {

        obj.transform.rotation *= Quaternion.Euler(180, 180, 0);
    }
    //For future use
    // void RotateZ(GameObject obj)
    // {
    //     float rotationZ = obj.transform.eulerAngles.z;
    //     obj.transform.rotation *= Quaternion.Euler(0, 180, rotationZ * 2);
    // }
    void Flip()
    {

        MovingPlatforms.speed = MovingPlatforms.speed * (-1);
        MovingPlatforms.edgey = MovingPlatforms.edgey * (-1);
        RotatingPlatforms.rpm = RotatingPlatforms.rpm * (-1);

        if (RotateXArr.Length != 0)
        {
            for (int i = 0; i < RotateXArr.Length; i++)
            {
                    FlipY(RotateXArr[i]);
                    RotateX(RotateXArr[i]);
            }
        }
        if (RotateXAndYArr.Length  != 0)
        {
            for (int i = 0; i < RotateXAndYArr.Length; i++)
            {
                FlipY(RotateXAndYArr[i]);
                RotateXAndY(RotateXAndYArr[i]);
            }
        }
    }


}
