using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour, ISubject
{
    public List<IObserver> backgroundObjects;
    
    // inclusive!
    public int maxThemes;
    private int currentTheme = 0;

    public float themeTime;

    private void Start()
    {
        backgroundObjects = new List<IObserver>();

        GameObject[] temp = GameObject.FindGameObjectsWithTag("BackgroundTheme");

        foreach (GameObject obj in temp)
            Register(obj.GetComponent<IObserver>());

        StartCoroutine(ChangeTheme());
    }

    public void Register(IObserver s)
    {
        if (backgroundObjects != null || !backgroundObjects.Contains(s))
            backgroundObjects.Add(s);
    }

    public void SendUpdate()
    {
        if(backgroundObjects != null)
        {
            // increment theme
            currentTheme++;
            if (currentTheme == maxThemes)
                currentTheme = 0;

            // send new theme to all observers
            foreach (IObserver bg in backgroundObjects)
            {
                bg.RecieveUpdate(currentTheme);
            }
        }
    }

    public void UnRegister(IObserver s)
    {
        if (backgroundObjects.Count > 0 && backgroundObjects.Contains(s))
            backgroundObjects.Remove(s);
    }

    IEnumerator ChangeTheme()
    {
        while(true)
        {
            yield return new WaitForSeconds(themeTime);
            SendUpdate();
            yield return null;
        }
    }
}
