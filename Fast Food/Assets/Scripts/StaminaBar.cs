using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value -= Time.deltaTime;
        if (staminaBar.value == 0)
        {
            Debug.Log("Game Over");
            GameManager.instance.GameOver();
        }
    }

    public void SmallEnergyRestore()
    {
        staminaBar.value += 10;
    }

    public void LargeEnergyRestore()
    {
        staminaBar.value += 20;
    }
}
