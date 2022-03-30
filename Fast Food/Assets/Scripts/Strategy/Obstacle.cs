/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * obstacle supertype
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public LaneBehavior laneBehavior;

    public Vector3 spawnPoint;
    public float zResetPoint;

    public GameObject[] themes;

    private void Awake()
    {
        PrepObs();

        foreach (GameObject obj in themes)
            obj.SetActive(false);

        // activate selected theme
        themes[GameManager.instance.theme].SetActive(true);
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * GameManager.instance.speed * -1 * Time.deltaTime);

        if (transform.position.z < zResetPoint)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void PrepObs();
}
