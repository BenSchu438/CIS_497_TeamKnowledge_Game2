/*
 * Team Knowledge
 * Spring21 Game2 - Fast Food
 * Player Movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Lane vectors
    private Vector3 leftLane = new Vector3(-7, 0, 0);
    private Vector3 rightLane = new Vector3(7, 0, 0);
    private Vector3 centerLane = new Vector3(0, 0, 0);
    public Vector3 currentLane;
    public float laneChangeTime;

    private bool jumping;
    private bool transitioning;
    

    private void Awake()
    {
        currentLane = centerLane;
        jumping = transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !transitioning)
        {
            Debug.Log("A pressed while not transitioning");

            if (currentLane.Equals(centerLane))
            {
                transitioning = true;
                StartCoroutine(ChangeLane(currentLane, leftLane));
            }
            else if (currentLane.Equals(rightLane))
            {
                transitioning = true;
                StartCoroutine(ChangeLane(currentLane, centerLane));
            }
            else
                Debug.Log("Too far left");
        }
        else if (Input.GetKeyDown(KeyCode.D) && !transitioning)
        {
            Debug.Log("D pressed while not transitioning");

            if (currentLane.Equals(centerLane))
            {
                transitioning = true;
                StartCoroutine(ChangeLane(currentLane, rightLane));
            }
            else if (currentLane.Equals(leftLane))
            {
                transitioning = true;
                StartCoroutine(ChangeLane(currentLane, centerLane));
            }
            else
                Debug.Log("Too far right");
        }
    }


    IEnumerator ChangeLane(Vector3 lane, Vector3 newLane)
    {
        float elapsedTime = 0;
        Vector3 temp = lane;
        
        while(elapsedTime < laneChangeTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(temp, newLane, elapsedTime / laneChangeTime);
            yield return null;
        }
        transform.position = newLane;
        currentLane = newLane;
        transitioning = false;
    }

}
