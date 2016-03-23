using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public static float offsetX;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BirdyScript.instance != null)
        {
            if (BirdyScript.instance.isAlive)
            {
                MoveTheCamera();
            }
        }
    }

    void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = BirdyScript.instance.GetPositionX() + offsetX;
        transform.position = temp;
    }
}
