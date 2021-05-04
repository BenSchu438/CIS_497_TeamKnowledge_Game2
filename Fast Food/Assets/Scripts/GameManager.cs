/* Team Knowledge 
 * Spring 2021 Group Game 2
 * Singleton Game Manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    public bool gameOver = false;
    public bool isPaused;
    public int speed;
    public int score;

    public int minSpeed;
    public int maxSpeed;

    public Text finalScore;

    public static GameManager instance;
    public static string CurrentLevelName = "MainMenu";


    // create singleton instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate second singleton");
        }
        speed = minSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPaused && !gameOver)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPaused && !gameOver)
        {
            UnPause();
        }
    }


    //load and unload levels
    public void LoadLevel(string levelName)
    {
        gameOver = false;
        gameOverScreen.SetActive(false);

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load: " + levelName);
            return;
        }
        CurrentLevelName = levelName;
        UnPause();
        score = 0;
        speed = minSpeed;
    }

    public void UnloadCurrentLevel()
    {
        gameOverScreen.SetActive(false);
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);

        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + CurrentLevelName);
        }
        CurrentLevelName = "MainMenu";

        UnPause();
    }
    public void ReloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + CurrentLevelName);
        }
        LoadLevel(CurrentLevelName);
    }

    //pausing and unpausing
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // call when game over is triggered
    public void GameOver()
    {
        if(CurrentLevelName == "Level1")
        {
            gameOver = true;
            Time.timeScale = 0f;
            finalScore.text = "Score: " + score;
            gameOverScreen.SetActive(true);
        }
    }
}
