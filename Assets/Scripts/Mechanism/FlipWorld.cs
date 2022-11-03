using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

public class FlipWorld : MonoBehaviour
{
    private static GameObject[] RotateXArr;
    private static GameObject[] RotateYArr;
    private static GameObject[] RotateXAndYArr;
    private static GameObject[] FinishFlag;

    void Start()
    {
        RotateXArr = GameObject.FindGameObjectsWithTag("RotateX");
        RotateYArr = GameObject.FindGameObjectsWithTag("RotateY");
        RotateXAndYArr = GameObject.FindGameObjectsWithTag("RotateXAndY");
        FinishFlag = GameObject.FindGameObjectsWithTag("FinishFlag");

        if (RotateXArr.Length != 0)
        {
            for (int i = 0; i < RotateXArr.Length; i++)
            {
                if (RotateXArr[i].GetComponent<Renderer>() != null && RotateXArr[i].transform.position.y > 0)
                {
                    RotateXArr[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f,0.2f);
                }
            }
        }
        if (RotateXAndYArr.Length != 0)
        {
            for (int i = 0; i < RotateXAndYArr.Length; i++)
            {
                if (RotateXAndYArr[i].GetComponent<Renderer>() != null && RotateXAndYArr[i].transform.position.y > 0)
                {
                    RotateXAndYArr[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f,0.2f);
                }
            }
        }

        if (RotateYArr.Length != 0)
        {
            for (int i = 0; i < RotateYArr.Length; i++)
            {
                if (RotateYArr[i].GetComponent<Renderer>() != null && RotateYArr[i].transform.position.y > 0)
                {
                    RotateYArr[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f,0.2f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameController.canMove)
        {
            Data.FlipCounts++;
            Flip();
            GameController.isWorldFlipped = !GameController.isWorldFlipped;
        }
    }
    static void FlipY(GameObject obj)
    {
      if(obj != null){
        Vector3 pos = obj.transform.position;
        pos.y = -pos.y;
        obj.transform.position = pos;
      }

    }
    static void RotateX(GameObject obj)
    {
      if(obj != null){
        obj.transform.rotation *= Quaternion.Euler(180, 0, 0);
      }

    }
    static void RotateY(GameObject obj)
    {
        obj.transform.rotation *= Quaternion.Euler(0, 180, 0);
    }

    static void RotateXAndY(GameObject obj)
    {
        obj.transform.rotation *= Quaternion.Euler(180, 180, 0);
    }
    static void ChangeOpacity(GameObject obj)
    {
        if (obj != null && obj.transform.position.y > 0)
        {
            obj.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
        }
        if (obj != null && obj.transform.position.y < 0)
        {
            obj.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    //For future use
    // void RotateZ(GameObject obj)
    // {
    //     float rotationZ = obj.transform.eulerAngles.z;
    //     obj.transform.rotation *= Quaternion.Euler(0, 180, rotationZ * 2);
    // }
    public static void Flip()
    {
        MovingPlatforms.speed *= (-1);
        MovingPlatforms.edgey *= (-1);
        RotatingPlatforms.rpm *= (-1);
        MovingPlatforms1.speed *= (-1);
        MovingPlatforms1.edgey *= (-1);
        MovingPlatforms2.speed *= (-1);
        MovingPlatforms2.edgey *= (-1);
        RotatingPlatforms1.dr *= (-1);

        if (RotateXArr.Length != 0)
        {
            for (int i = 0; i < RotateXArr.Length; i++)
            {
                    FlipY(RotateXArr[i]);
                    RotateX(RotateXArr[i]);
                    ChangeOpacity(RotateXArr[i]);
            }
        }
        if (RotateXAndYArr.Length != 0)
        {
            for (int i = 0; i < RotateXAndYArr.Length; i++)
            {
                FlipY(RotateXAndYArr[i]);
                RotateXAndY(RotateXAndYArr[i]);
                ChangeOpacity(RotateXAndYArr[i]);
            }
        }

        if (RotateYArr.Length != 0)
        {
            for (int i = 0; i < RotateYArr.Length; i++)
            {
                FlipY(RotateYArr[i]);
                RotateY(RotateYArr[i]);
                ChangeOpacity(RotateYArr[i]);
            }
        }

        if (FinishFlag.Length != 0)
        {
            for (int i = 0; i < FinishFlag.Length; i++)
            {
                FlipY(FinishFlag[i]);
                RotateXAndY(FinishFlag[i]);
            }
        }
    }


}
