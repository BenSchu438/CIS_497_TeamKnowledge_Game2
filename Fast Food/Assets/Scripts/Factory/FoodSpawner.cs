using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodOptions;

    public int minWaveSpawn = 1;
    public int maxWaveSpawn = 3;

    public float delay;

    // set minor 2 second delay before starting system
    private void Awake()
    {
        StartCoroutine(NextWave(2f));
    }

    public void SpawnNextWave()
    {
        // decide how many objects to spawn
        int obsQuantity = Random.Range(minWaveSpawn, maxWaveSpawn);
        List<int> selectedObj = new List<int>();

        // select however many obstacles to spawn
        for (int i = 0; i <= obsQuantity; i++)
        {
            int temp = Random.Range(0, foodOptions.Length);

            // ensure no duplicates but count is still reached
            if (selectedObj.Contains(temp))
                i--;
            else
                selectedObj.Add(temp);
        }

        // spawn the objects
        foreach (int obj in selectedObj)
        {
            Instantiate(foodOptions[obj], foodOptions[obj].transform.position, foodOptions[obj].transform.rotation);
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

    public void SetDifficulty(int minObs, int maxObs, float _delay)
    {
        minWaveSpawn += minObs;
        maxWaveSpawn += maxObs;
        delay += _delay;

        // ensure atleast 1 second delay between objects
        if (delay < 1.1f)
            delay = 1.1f;

        // ensure it can only spawn a max of 5 and min of 4 for balance
        if (minWaveSpawn > 4)
            minWaveSpawn = 4;
        if (maxWaveSpawn > 5)
            maxWaveSpawn = 5;
    }
}
