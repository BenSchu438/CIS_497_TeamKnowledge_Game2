using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakDebuff : DebuffDecorator
{
    Body buildup;

    public WeakDebuff(Body b)
    {
        buildup = b;
    }

    public override int GetDamage()
    {
        return buildup.GetDamage() - 3;
    }

    public override int GetJunkCount()
    {
        return buildup.GetJunkCount() + 1;
    }
}
