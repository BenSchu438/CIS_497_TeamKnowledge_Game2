/* * Logan Ross 
 * * ScoreManager.cs 
 * * Assignment 10
 * * Handles all of the object pooling
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclePooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObstaclePooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(GameManager.CurrentLevelName));


        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        StartCoroutine(spawnObstacles());
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);

        // randomly have high and low obstalcles
        Vector3 nextPos;

        if (Random.Range(0, 3) < 2)
        {
            // basic ground obstacle
            nextPos = new Vector3(position.x, 0.6f, position.z);
            objectToSpawn.transform.localScale = new Vector3(12, 1, 1);
        }
            
        else
        {
            // basic floating obstacle
            nextPos = new Vector3(position.x, 3.5f, position.z);
            objectToSpawn.transform.localScale = new Vector3(12, 4, 1);
        }
            

        objectToSpawn.transform.position = nextPos;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    IEnumerator spawnObstacles()
    {
        Debug.Log("start spawn");
        while (true)
        {
            Debug.Log("spawn");

            yield return new WaitForSeconds(Random.Range(1f, 3f));
            SpawnFromPool("Obstacle", transform.position, Quaternion.identity);
        }
    }

}
