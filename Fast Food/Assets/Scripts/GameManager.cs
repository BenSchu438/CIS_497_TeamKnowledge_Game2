/* * Logan Ross 
 * * GameManger.cs 
 * * Assignment 10
 * * spawns obstacles and checks for game over
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        Time.timeScale = 1f;
        
        speed = gameSpeed;
    }

    public void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivateGameOverScreen()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

}
