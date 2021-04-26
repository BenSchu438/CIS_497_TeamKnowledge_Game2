/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * Subject interface
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public void Register(IObserver s);
    public void UnRegister(IObserver s);
    public void SendUpdate();
}
