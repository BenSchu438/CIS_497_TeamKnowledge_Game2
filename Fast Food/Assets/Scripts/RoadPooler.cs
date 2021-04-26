/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Pooler for road objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadPooler : MonoBehaviour
{
    // this will include mid lane, left land and right lane
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // using ints that correspond to their x position (-4, 0, 4)

    public static RoadPooler instance;
    public float roadSpawnPoint;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(GameManager.CurrentLevelName));
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        SpawnRoadPools();
    }

    // Spawn each lane with its max amount of roads. Space them 4 gaps apart (perfect fit)
    private void SpawnRoadPools()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            int spawnPos = 0;
            
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                obj.transform.position = new Vector3(pool.lanePos, 0, spawnPos);
                objectPool.Enqueue(obj);

                spawnPos += 4;
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // when called, teleport road component back to start
    public void ResetRoadFromPool(string tag, float xPos)
    {
        if (!poolDictionary.ContainsKey(tag))
            Debug.LogWarning("Pool with tag " + tag + " does not exist!");

        GameObject obj = poolDictionary[tag].Dequeue();

        obj.transform.position = new Vector3(xPos, 0, roadSpawnPoint);

        poolDictionary[tag].Enqueue(obj);
    }
}
