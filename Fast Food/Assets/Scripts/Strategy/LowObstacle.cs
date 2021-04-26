/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * concrete obstacle type
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowObstacle : Obstacle
{
    public override void PrepObs()
    {
        transform.position = new Vector3(spawnPoint.x, 0.75f, spawnPoint.z);

        transform.localScale = new Vector3(transform.localScale.x, 1.5f, transform.localScale.z);

        laneBehavior.SetLanePos();
    }
}
