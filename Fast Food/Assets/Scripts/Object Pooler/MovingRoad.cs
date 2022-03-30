/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Road stripes to go down road
 */
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
    void FixedUpdate()
    {
        transform.Translate(transform.forward * GameManager.instance.speed * -1 * Time.deltaTime);

        if(transform.position.z <= requeueZ)
        {
            RoadPooler.instance.ResetRoadFromPool(poolTag, lanePos);
        }
    }
}
