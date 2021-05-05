/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Individual background objects, change theme when told
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundThemes : MonoBehaviour, IObserver
{
    public GameObject[] themes;

    public int currentTheme = 0;

    public float resetPoint;
    public float offScreen = -8;
    private bool justChanged = false;

    public void RecieveUpdate(int theme)
    {
        currentTheme = theme;
        justChanged = true;
    }

    private void Update()
    {
        transform.Translate(transform.forward * -1  * GameManager.instance.speed * Time.deltaTime);

        if (transform.position.z < offScreen)
            ResetObject();
    }

    private void ResetObject()
    {
        transform.position = transform.position = new Vector3(transform.position.x, transform.position.y, resetPoint);
        
        // check if a new theme was set. If so, change to that theme.
        if(justChanged)
        {
            // turn off all themes
            foreach (GameObject theme in themes)
                theme.SetActive(false);

            // activate selected theme
            themes[currentTheme].SetActive(true);

            justChanged = false;
        }
    }
}
