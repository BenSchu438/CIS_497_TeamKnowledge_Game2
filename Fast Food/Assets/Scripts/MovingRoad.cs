using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRoad : MonoBehaviour
{
    public string poolTag;
    //public float speed;
    public float requeueZ;
    public float lanePos;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * GameManager.instance.speed * -1 * Time.deltaTime);

        if(transform.position.z <= requeueZ)
        {
            RoadPooler.instance.ResetRoadFromPool(poolTag, lanePos);
        }
    }
}
