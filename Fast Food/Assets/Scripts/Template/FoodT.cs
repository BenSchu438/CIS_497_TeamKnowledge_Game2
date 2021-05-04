/* Team Knowledge 
 * Spring 2021 Group Game 2
 * concrete tutorial template. Forces player to eat 5 foods
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodT : AbstractTutorial
{
    public static int foodCount;
    public int foodCountLimit;
    public GameObject foodManager;

    private void Start()
    {
        foodCount = 0;
    }

    protected override void CheckProgress()
    {
        foodManager.SetActive(true);
        foodCount = 0;
    }

    private void Update()
    {
        if(foodCount >= foodCountLimit)
        {
            SetNextTutorial();
        }
    }
}
