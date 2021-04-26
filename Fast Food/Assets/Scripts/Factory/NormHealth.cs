using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormHealth : Food
{
    public override void PrepFood()
    {
        transform.position = new Vector3(spawnPoint.x, 2.6f, spawnPoint.z);

        transform.localScale = new Vector3(transform.localScale.x, 3.8f, transform.localScale.z);

    }
}
