/*
 * Team Knowledge
 * SP21 Game 2 [Fast Food]
 * junk food factory
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : Factory
{
    // prefab for vampires
    public GameObject weakJunk;
    public GameObject normJunk;
    public GameObject superJunk;

    public override GameObject CreateFood(string type)
    {
        GameObject temp = null;

        if (type.Equals("Weak"))
        {
            temp = weakJunk;
        }
        else if (type.Equals("Norm"))
        {
            temp = normJunk;
        }
        else if (type.Equals("Super"))
        {
            temp = superJunk;
        }

        return temp;
    }
}