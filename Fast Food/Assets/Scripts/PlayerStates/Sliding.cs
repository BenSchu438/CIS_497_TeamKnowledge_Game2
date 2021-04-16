using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour, IState
{
    public PlayerController p;
    public Rigidbody rb;

    public void ChangeLane(string direction)
    {
        Debug.Log("I'm sliding! I can't change lane!");
    }

    public void Jump()
    {
        // cancel slide
        PlayerController.sliding = false;
        GetComponent<Renderer>().material = p.defMat;
        transform.localScale += new Vector3(0, p.slideHeight, 0);
        transform.position = new Vector3(0, 1f, 0);
        //rb.velocity = new Vector3(0, 0, 0);

        // jump
        p.currentState = p.jump;
        rb.AddForce(transform.up * p.jumpForce, ForceMode.Impulse);
    }

    public void Slide()
    {
        Debug.Log("I'm sliding! I can't slide further!");
    }
}
