using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int difficultyMilestone;
    [SerializeField] private int speedModifier;

    public GameObject obstacleSpawner;
    public GameObject foodSpawner;
    private ObstacleSpawner obsSpawner;
    private FoodSpawner fdSpawner;
    private int initialSpeed;

    private void Awake()
    {
        obsSpawner = obstacleSpawner.GetComponent<ObstacleSpawner>();
        fdSpawner = foodSpawner.GetComponent<FoodSpawner>();
        speedModifier = GameManager.instance.speed;

        StartCoroutine(ScoreIncrementer());
    }

    IEnumerator ScoreIncrementer()
    {
        int difficultyIncrement = 0;
        initialSpeed = GameManager.instance.minSpeed;

        while(true)
        {
            GameManager.instance.score += 1 * GameManager.instance.speed;
            scoreText.text = "Score: " + GameManager.instance.score;
            difficultyIncrement = GameManager.instance.score / difficultyMilestone;

            // check if milestone reached for difficulty increase
            if (speedModifier != initialSpeed + difficultyIncrement)
                speedModifier = initialSpeed + difficultyIncrement;

            // check if it can be incremented
            if (speedModifier != GameManager.instance.speed && (GameManager.instance.speed < GameManager.instance.maxSpeed))
            {
                GameManager.instance.speed = speedModifier;
                //Debug.Log("Increasing Speed...");

                // every other increment, modify the obstacle/food delay
                if (difficultyIncrement % 2 == 0)
                {
                    //Debug.Log("Decreasing time between obstacles...");
                    obsSpawner.SetDifficulty(0, 0, -0.5f);
                    fdSpawner.ModFoodDelay(-0.5f);
                }
                // every third increment, increase the amount of obstacles spawned
                if (difficultyIncrement % 3 == 0)
                {
                    //Debug.Log("Increasing obstacles...");
                    obsSpawner.SetDifficulty(1, 1, 0);
                }
            }
            else if (GameManager.instance.speed >= GameManager.instance.maxSpeed)
                GameManager.instance.speed = GameManager.instance.maxSpeed;
                

            yield return new WaitForSeconds(1f);
        }
    }
}
