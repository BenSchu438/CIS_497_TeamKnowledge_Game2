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
    private bool transitioning;

    // Lane reference
    [Header("Movement Values")]
    public float laneChangeTime;
    public Lane currentLane;
    [Space(5)]

    //moving stuff
    public static bool jumping;
    [Header("Jumping Values")]
    public float jumpTransitionTime;
    public float jumpDuration;
    public float jumpHeight;
    [Space(5)]

    public static bool sliding;
    [Header("Sliding Values")]
    public float slideTransitionTime;
    public float slideDuration;
    public float slideHeight;




    private void Awake()
    {
        jumping = transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        // go left if possible
        if (Input.GetKeyDown(KeyCode.A) && !jumping && !transitioning && !sliding)
        {
            if (currentLane.HasLeftLane())
                ChangeLane("Left");
            else
                Debug.Log("No left lane!");
        }
        // go right if possible
        else if (Input.GetKeyDown(KeyCode.D) && !jumping && !transitioning && !sliding)
        {
            if (currentLane.HasRightLane())
                ChangeLane("Right");
            else
                Debug.Log("No right lane!");
        }
        // jump if possible
        else if(Input.GetKeyDown(KeyCode.W) && !jumping && !transitioning && !sliding)
        {
            StartCoroutine(Jump());
        }
        // slide if possible
        else if (Input.GetKeyDown(KeyCode.S) && !jumping && !transitioning && !sliding)
        {
            StartCoroutine(Slide());
        }
    }

    public void ChangeLane(string direction)
    {
        if(direction == "Left")
        {
            transitioning = true;
            currentLane = currentLane.GetLeftLane();
            StartCoroutine(ChangeLane());
        }
        else if (direction == "Right")
        {
            transitioning = true;
            currentLane = currentLane.GetRightLane();
            StartCoroutine(ChangeLane());
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
    IEnumerator Jump()
    {
        // values
        jumping = true;
        Vector3 startPos = transform.position;
        Vector3 jumpPos = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);

        // jump in air
        float elapsedTime = 0;
        while(elapsedTime < jumpTransitionTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, jumpPos, elapsedTime / jumpTransitionTime);
            yield return null;
        }
        transform.position = jumpPos;

        // air time
        yield return new WaitForSeconds(jumpDuration);

        // fall to ground
        elapsedTime = 0;
        while (elapsedTime < jumpTransitionTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(jumpPos, startPos, elapsedTime / jumpTransitionTime);
            yield return null;
        }
        transform.position = startPos;

        // finish jump
        jumping = false;
    }

    IEnumerator Slide()
    {
        // values
        sliding = true;
        Vector3 startPos = transform.position;
        Vector3 slidePos = new Vector3(transform.position.x, transform.position.y - slideHeight, transform.position.z);

        // jump in air
        float elapsedTime = 0;
        while (elapsedTime < slideTransitionTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, slidePos, elapsedTime / slideTransitionTime);
            yield return null;
        }
        transform.position = slidePos;

        // air time
        yield return new WaitForSeconds(slideDuration);

        // fall to ground
        elapsedTime = 0;
        while (elapsedTime < slideTransitionTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(slidePos, startPos, elapsedTime / slideTransitionTime);
            yield return null;
        }
        transform.position = startPos;

        // finish jump
        sliding = false;
    }

}
