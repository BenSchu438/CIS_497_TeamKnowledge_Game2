/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * concrete junk food
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJunk : Food
{
    public int stamina;
    public int health;
    public override void PrepFood()
    {
        staminaIncrease = stamina;
        healthChange = health;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        healthBarScript.JunkFoodBuildup(HealthBar.FoodType.strong);
    }

}