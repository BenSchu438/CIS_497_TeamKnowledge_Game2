/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * concrete jumping state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour, IState
{
    public void ChangeLane(string direction)
    {
        //Debug.Log("I'm mid air! I can't change lane!");
    }

    public void Jump()
    {
        //Debug.Log("I'm mid air! I can't jump again!");
    }

    public void Slide()
    {
        //Debug.Log("I'm mid air! I can't slide!");
    }
}
