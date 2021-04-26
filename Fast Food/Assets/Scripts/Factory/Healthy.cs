using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : Factory
{
    // prefab for vampires
    public GameObject weakHealth;
    public GameObject normHealth;
    public GameObject superHealth;

    public override GameObject CreateFood(string type)
    {
        GameObject temp = null;

        if (type.Equals("Weak"))
        {
            temp = weakHealth;
        }
        else if (type.Equals("Norm"))
        {
            temp = normHealth;
        }
        else if (type.Equals("Super"))
        {
            temp = superHealth;
        }

        return temp;
    }
}