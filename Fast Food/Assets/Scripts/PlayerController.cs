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
    [Header("Movement Values")]
    public float laneChangeTime;
    public Lane currentLane;
    [Space(5)]

    // moving stuff
    [Header("Jumping Values")]
    public float jumpForce;
    public float gravityModifier;
    [Space(5)]

    public static bool sliding;

    [Header("Sliding Values")]
    public float slideDuration;
    public float slideHeight;
    public Material defMat;
    public Material slideIndic;

    [Header("Healthbar Ref")]
    public HealthBar health;
    public float iframe;
    private bool immune;
    [Space(5)]

    [SerializeField] public IState currentState;
    public IState running;
    public IState trans;
    public IState slide;
    public IState jump;

    public Rigidbody playerRb;
    private Animator ani;

    private void Awake()
    {
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        immune = false;
        ani = GetComponentInChildren<Animator>(true);

        if (Physics.gravity.y > -10)
            Physics.gravity *= gravityModifier;

        // set state stuff
        running = GetComponent<Running>();
        trans = GetComponent<Transitioning>();
        slide = GetComponent<Sliding>();
        jump = GetComponent<Jumping>();
        currentState = running;
    }

    // Update is called once per frame
    void Update()
    {
        // go left if possible w/ a
        if (Input.GetKey(KeyCode.A))
        {
            if (currentLane.HasLeftLane())
            {
                currentState.ChangeLane("Left");
            }
            //else
            //    Debug.Log("No left lane!");
        }
        // go right if possible w/ d
        else if (Input.GetKey(KeyCode.D))
        {
            if (currentLane.HasRightLane())
            {
                currentState.ChangeLane("Right");
            }
                
            //else
            //    Debug.Log("No right lane!");
        }
        // jump if possible w/ w or space
        else if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            currentState.Jump();
            ani.SetTrigger("Jump");
            ani.SetBool("Grounded", false);
        }
        // slide if possiblew/ s or left control
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl)))
        {
            currentState.Slide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !immune)
        {
            StartCoroutine(Iframe());
            health.HealthDrop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && currentState == jump)
        {
            currentState = running;
            ani.SetBool("Grounded", true);
        }       
    }

    private IEnumerator Iframe()
    {
        immune = true;
        yield return new WaitForSeconds(iframe);
        immune = false;
    }
}
