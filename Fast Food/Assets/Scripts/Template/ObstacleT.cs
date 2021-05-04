/* Team Knowledge 
 * Spring 2021 Group Game 2
 * concrete tutorial template. Makes player play through 5 waves of obstacles
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleT : AbstractTutorial
{
    public float delay;
    public GameObject obstacleManager;

    protected override void CheckProgress()
    {
        // Activate obstacleManager. Wait for a few seconds to allow player to test it
        obstacleManager.SetActive(true);
        StartCoroutine(AllowObstacles());
    }

    IEnumerator AllowObstacles()
    {
        yield return new WaitForSeconds(delay);
        SetNextTutorial();
    }
}
