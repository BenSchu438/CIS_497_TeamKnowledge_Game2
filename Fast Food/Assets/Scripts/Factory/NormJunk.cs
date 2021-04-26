using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormJunk : Food
{
    public override void PrepFood()
    {
        random = Random.Range(1, 3);
        if (random == 1)
        {
            spawnPoint = new Vector3(-4, 0, 95);
        }
        else if (random == 2)
        {
            spawnPoint = new Vector3(0, 0, 95);
        }
        else
        {
            spawnPoint = new Vector3(4, 0, 95);
        }
        transform.position = new Vector3(spawnPoint.x, 2.6f, spawnPoint.z);

        transform.localScale = new Vector3(transform.localScale.x, 3.8f, transform.localScale.z);

    }
    

}
