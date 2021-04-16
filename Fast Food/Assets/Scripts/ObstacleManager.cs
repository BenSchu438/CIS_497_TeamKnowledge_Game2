/* * Logan Ross 
 * * ScoreManager.cs 
 * * Assignment 10
 * * Moves obstacles twords the player
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(transform.forward * GameManager.speed * -1 * Time.deltaTime);
    }
}
