/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * state interface
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void ChangeLane(string direction);
    void Jump();
    void Slide();

}
