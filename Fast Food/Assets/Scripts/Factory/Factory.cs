/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * food factory superclass
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    //variables for spawning
    public int minX = -6;
    public int maxX = 9;

    public void SpawnFood(string type)
    {
        GameObject food = CreateFood(type);

        if (food != null)
        {
            int ranX = Random.Range(minX, maxX);
            Vector3 pos = new Vector3(ranX, 0, 0);
            Instantiate(food, pos, food.transform.rotation);
        }
    }

    public abstract GameObject CreateFood(string type);
}
