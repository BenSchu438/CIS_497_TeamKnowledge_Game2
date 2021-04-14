using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public GameObject staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaBar.GetComponent<Slider>().value == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
