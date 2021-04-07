using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public float xPlayerPosition;
    public Vector3 obstaclePosition;

    public Lane leftLane;
    public Lane rightLane;

    public float speed;
    public float destroyRange;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * -1 * speed * Time.deltaTime);

    }

    public bool IsLeftLane()
    {
        return leftLane != null;
    }
    public bool IsRightLane()
    {
        return rightLane != null;
    }
}
