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
    public Slider healthBar;
    public int damage;
    public float IframeTime;
    public bool damageable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        healthBar.value += value;
        StartCoroutine(Iframe());

    }

    IEnumerator Iframe()
    {
        damageable = false;
        yield return new WaitForSeconds(IframeTime);
        damageable = true;
    }
}
