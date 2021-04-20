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
<<<<<<< Updated upstream
    public float gameSpeed;
    public static float speed;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    //singleton
    #region 
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
=======
    public bool gameOver = false;
    public bool isPaused;
    public float speed;
    public int score;
>>>>>>> Stashed changes

    public static GameManager instance;
    public static string CurrentLevelName = "MainMenu";

    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    // create singleton instance
    private void Awake()
    {
<<<<<<< Updated upstream
        Time.timeScale = 1f;
        
        speed = gameSpeed;
=======
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate second singleton");
        }
>>>>>>> Stashed changes
    }

    private void Update()
    {
<<<<<<< Updated upstream
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
=======
        if(Input.GetKeyDown(KeyCode.Tab) && !isPaused && !gameOver)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPaused && !gameOver)
        {
            UnPause();
>>>>>>> Stashed changes
        }
    }

    //load and unload levels
    public void LoadLevel(string levelName)
    {
        gameOver = false;
        score = 0;
        gameOverScreen.SetActive(false);

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load: " + levelName);
            return;
        }
        CurrentLevelName = levelName;

        UnPause();
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
<<<<<<< Updated upstream
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

=======
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + CurrentLevelName);
        }
        LoadLevel(CurrentLevelName);
    }

    //pausing and unpausing
>>>>>>> Stashed changes
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
<<<<<<< Updated upstream
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
=======
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
>>>>>>> Stashed changes
    }

    // call when game over is triggered
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }
}
