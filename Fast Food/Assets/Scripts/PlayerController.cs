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
    // Lane reference
    public Lane currentLane;
    public float laneChangeTime;

    //moving stuff
    private bool jumping;
    private bool transitioning;
    

    private void Awake()
    {
        jumping = transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        // try to go left if possible
        if (Input.GetKeyDown(KeyCode.A) && !transitioning)
        {
            if (currentLane.HasLeftLane())
            {
                transitioning = true;
                currentLane = currentLane.GetLeftLane();
                StartCoroutine(ChangeLane());
            }
            else
                Debug.Log("No left lane!");

        }
        // try to go right if possible
        else if (Input.GetKeyDown(KeyCode.D) && !transitioning)
        {
            if (currentLane.HasRightLane())
            {
                transitioning = true;
                currentLane = currentLane.GetRightLane();
                StartCoroutine(ChangeLane());
            }
            else
                Debug.Log("No right lane!");
        }
    }


    IEnumerator ChangeLane()
    {
        float elapsedTime = 0;

        Vector3 cLane = transform.position;
        Vector3 nLane = new Vector3(currentLane.transform.position.x, transform.position.y, transform.position.z);
        
        while(elapsedTime < laneChangeTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(cLane, nLane, elapsedTime / laneChangeTime);
            yield return null;
        }
        transform.position = nLane;
        transitioning = false;
    }

}
