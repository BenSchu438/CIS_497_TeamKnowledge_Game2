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

    [SerializeField] public IState currentState;
    public IState running;
    public IState trans;
    public IState slide;
    public IState jump;

    public GameManager gm;
    public Rigidbody playerRb;

    private void Awake()
    {
        playerRb = this.gameObject.GetComponent<Rigidbody>();

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentLane.HasLeftLane())
            {
                currentState.ChangeLane("Left");
            }
            else
                Debug.Log("No left lane!");
        }
        // go right if possible w/ d
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (currentLane.HasRightLane())
            {
                currentState.ChangeLane("Right");
            }
                
            else
                Debug.Log("No right lane!");
        }
        // jump if possible w/ w or space
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            currentState.Jump();
        }
        // slide if possiblew/ s or left control
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow))
        {
            currentState.Slide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
<<<<<<< Updated upstream
            GameManager.instance.ActivateGameOverScreen();
=======
            GameManager.instance.GameOver();
>>>>>>> Stashed changes
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && currentState == jump)
        {
            currentState = running;
        }
            
    }
}
