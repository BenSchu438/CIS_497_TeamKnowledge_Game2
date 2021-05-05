using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongDebuff : DebuffDecorator
{
    Body buildup;

    public StrongDebuff(Body b)
    {
        buildup = b;
    }

    public override int GetDamage()
    {
        return buildup.GetDamage() - 7;
    }

    public override int GetJunkCount()
    {
        return buildup.GetJunkCount() + 1;
    }

}