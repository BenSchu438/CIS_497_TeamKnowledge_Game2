using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public LaneBehavior laneBehavior;

    public Vector3 spawnPoint;
    public float zResetPoint;

    private void Awake()
    {
        PrepObs();
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * GameManager.instance.speed * -1 * Time.deltaTime);

        if (transform.position.z < zResetPoint)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void PrepObs();
}
