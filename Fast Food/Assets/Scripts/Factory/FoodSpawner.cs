/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Spawner for food objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodOptions;
    public Vector3[] spawnOptions;

    public int minWaveSpawn;
    public int maxWaveSpawn;

    public float delay;

    // set minor 2 second delay before starting system
    private void Awake()
    {
        StartCoroutine(NextWave(0.4f));
    }

    public void SpawnNextWave()
    {
        // decide how many objects to spawn
        int obsQuantity = Random.Range(minWaveSpawn, maxWaveSpawn);
        List<int> selectedObj = new List<int>();

        // select however many spawn positions to spawn
        for (int i = 0; i <= obsQuantity; i++)
        {
            int temp = Random.Range(0, spawnOptions.Length);

            // ensure no duplicates but count is still reached
            if (selectedObj.Contains(temp))
                i--;
            else
                selectedObj.Add(temp);
        }

        // spawn the objects
        foreach (int pos in selectedObj)
        {
            // select a random food
            int obj = Random.Range(0, foodOptions.Length);
            // spawn random food at predetermined points
            Instantiate(foodOptions[obj], spawnOptions[pos], foodOptions[obj].transform.rotation);
        }

        // Set a delay until the next wave of obstacles
        StartCoroutine(NextWave(delay));
    }

    IEnumerator NextWave(float time)
    {
        // wait for set time, then spawn next wave
        yield return new WaitForSeconds(time);
        SpawnNextWave();
    }

    public void ModFoodDelay(float _delay)
    {
        delay += _delay;

        // ensure atleast 1.4 second delay between objects
        if (delay < 1.4f)
            delay = 1.4f;
    }
}
