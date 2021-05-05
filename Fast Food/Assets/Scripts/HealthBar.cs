/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Health system for player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public enum FoodType
    {
        weak, 
        norm, 
        strong,
    }

    public Slider healthBar;
    public int damage;
    public float IframeTime;
    public bool damageable = true;

    // scaling junkfood system
    protected static Body buildup;

    private void Start()
    {
        buildup = new FatBuildup();
    }

    void FixedUpdate()
    {
        if (healthBar.value <= 0)
        {
            Debug.Log("Game Over");
            GameManager.instance.GameOver();
        }
        
        healthBar.value += Time.deltaTime;
    }

    public void HealthDrop()
    {
        healthBar.value -= damage;
        StartCoroutine(Iframe());
    }

    public void HealthRestore()
    {
        healthBar.value += 5;
    }

    public void ChangeHealthBar(int value)
    {
        // change based on input amount
        healthBar.value += value;

        if(value < 0)
        {
            // negative means damage. Calculate additional damage
            healthBar.value += buildup.GetDamage();
            Debug.Log("Additonal Damage Taken: " + buildup.GetDamage());
        }
        

        StartCoroutine(Iframe());

    }

    public void JunkFoodBuildup(FoodType t)
    {
        if (t == FoodType.weak)
            buildup = new WeakDebuff(buildup);
        else if (t == FoodType.norm)
            buildup = new NormDebuff(buildup);
        else if (t == FoodType.strong)
            buildup = new NormDebuff(buildup);
    }

    public static int GetFinalJunkCount()
    {
        return buildup.GetJunkCount();
    }

    IEnumerator Iframe()
    {
        damageable = false;
        yield return new WaitForSeconds(IframeTime);
        damageable = true;
    }
}
