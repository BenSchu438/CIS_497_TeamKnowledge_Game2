/* Team Knowledge 
 * Spring 2021 Group Game 2
 * concrete tutorial template. keeps track of player movement inputs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementT : AbstractTutorial
{
    private bool startChecking, moveLeft, moveRight, jump, slide;
    private int tutStage;

    protected override void CheckProgress()
    {
        // check to make sure the player has used each movement 
        tutStage = 0;
        startChecking = true;
        moveLeft = moveRight = jump = slide = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !moveLeft && startChecking)
        {
            moveLeft = true;
            tutStage++;
            if (tutStage >= 4)
            {
                // Stage done. Progress.
                Debug.Log("Movement tutorial complete");
                SetNextTutorial();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && !moveRight && startChecking)
        {
            moveRight = true;
            tutStage++;
            if (tutStage >= 4)
            {
                // Stage done. Progress.
                Debug.Log("Movement tutorial complete");
                SetNextTutorial();
            }
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && !jump && startChecking)
        {
            jump = true;
            tutStage++;
            if (tutStage >= 4)
            {
                // Stage done. Progress.
                Debug.Log("Movement tutorial complete");
                SetNextTutorial();
            }
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl)) && !slide && startChecking)
        {
            slide = true;
            tutStage++;
            if (tutStage >= 4)
            {
                // Stage done. Progress.
                Debug.Log("Movement tutorial complete");
                SetNextTutorial();
            }
        }

        
    }
}
