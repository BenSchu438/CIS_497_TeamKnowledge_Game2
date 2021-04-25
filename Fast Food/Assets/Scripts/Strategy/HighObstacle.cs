using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighObstacle : Obstacle
{
    public override void PrepObs()
    {
        transform.position = new Vector3(spawnPoint.x, 2.6f, spawnPoint.z);

        transform.localScale = new Vector3(transform.localScale.x, 3.8f, transform.localScale.z);

        laneBehavior.SetLanePos();
    }
}
