using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHealth : Food
{
    public override void PrepFood()
    {
        transform.position = new Vector3(spawnPoint.x, .75f, spawnPoint.z);

        transform.localScale = new Vector3(transform.localScale.x, 1.5f, transform.localScale.z);
    }
}
