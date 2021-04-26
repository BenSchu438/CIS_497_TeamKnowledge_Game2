/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * concrete lane behavior
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLane : LaneBehavior
{
    public override void SetLanePos()
    {
        this.gameObject.transform.position = new Vector3(-4, transform.position.y, transform.position.z);
    }
}
