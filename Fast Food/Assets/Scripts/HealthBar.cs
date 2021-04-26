using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public int damage;

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
    }

    public void HealthRestore()
    {
        healthBar.value += 5;
    }

    public void ChangeHealthBar(int value)
    {
        healthBar.value += value;
    }
}
