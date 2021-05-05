/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * food parent abstract
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Food : MonoBehaviour
{
    protected int staminaIncrease = 10;
    protected int healthChange = 0;
    public Vector3 spawnPoint;
    public float zResetPoint;
    //public int random;
    private Slider staminaBar;
    private GameObject healthBar;
    protected HealthBar healthBarScript;
    private StaminaBar staminaBarScript;


    private void Awake()
    {
        PrepFood();
        healthBarScript = GameObject.FindGameObjectWithTag("HealthBar").GetComponent <HealthBar>();
        staminaBarScript = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<StaminaBar>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        healthBarScript.ChangeHealthBar(healthChange);
        staminaBarScript.ChangeStaminaBar(staminaIncrease);
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * GameManager.instance.speed * -1 * Time.deltaTime);

        if (transform.position.z < zResetPoint)
        {
            Destroy(this.gameObject);
        }
    }
    public abstract void PrepFood();
}