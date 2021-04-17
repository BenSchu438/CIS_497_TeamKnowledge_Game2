using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour, IState
{
    public PlayerController p;
    public Rigidbody rb;

    public void ChangeLane(string direction)
    {
        p.currentState = p.trans;

        if (direction == "Left")
        {
            p.currentLane = p.currentLane.GetLeftLane();
            p.StartCoroutine(DoChangeLane());
        }
        else if (direction == "Right")
        {
            p.currentLane = p.currentLane.GetRightLane();
            StartCoroutine(DoChangeLane());
        }
    }
    IEnumerator DoChangeLane()
    {
        Vector3 cLane = transform.position;
        Vector3 nLane = new Vector3(p.currentLane.transform.position.x, transform.position.y, transform.position.z);

        float elapsedTime = 0;
        while (elapsedTime < p.laneChangeTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(cLane, nLane, elapsedTime / p.laneChangeTime);
            yield return null;
        }
        transform.position = nLane;
        p.currentState = p.running;
    }

    public void Jump()
    {
        p.currentState = p.jump;
        rb.AddForce(transform.up * p.jumpForce, ForceMode.Impulse);
    }

    public void Slide()
    {
        p.currentState = p.slide;
        StartCoroutine(DoSlide());
    }

    IEnumerator DoSlide()
    {
        // start sliding
        PlayerController.sliding = true;
        GetComponent<Renderer>().material = p.slideIndic;
        transform.localScale -= new Vector3(0, p.slideHeight, 0);
        
        // ground time
        yield return new WaitForSeconds(p.slideDuration);

        // if still sliding, revert to running
        if(p.currentState == p.slide)
        {
            GetComponent<Renderer>().material = p.defMat;
            transform.localScale += new Vector3(0, p.slideHeight, 0);
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            //rb.velocity = new Vector3(0, 0, 0);
            p.currentState = p.running;
        }
    }
}
