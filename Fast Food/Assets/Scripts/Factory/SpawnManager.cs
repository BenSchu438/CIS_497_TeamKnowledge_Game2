/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Spawn manager for Factory
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Factory currentFac;
    public GameObject factories;

    private bool isHealthy;

    public GameObject healthy;
    public GameObject junk;

    public void Start()
    {
        currentFac = factories.GetComponent<Junk>();
    }

    public void ChangeFactory()
    {
        if (isHealthy)
        {
            isHealthy = false;
            currentFac = factories.GetComponent<Healthy>();
        }
        else
        {
            isHealthy = true;
            currentFac = factories.GetComponent<Junk>();
        }
    }

    public void SpawnFood(string type)
    {
        currentFac.SpawnFood(type);
    }
}