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
    public static bool gameOver = false;
    public float gameSpeed;
    public static float speed;

    private void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        speed = gameSpeed;
    }

    public void FixedUpdate()
    {
        if(gameOver)
        {
            Time.timeScale = 0f;
            ActivateGameOverScreen();
        }
    }

    public void ResartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivateGameOverScreen()
    {
        Debug.Log("game over screen to be added");
    }

}
