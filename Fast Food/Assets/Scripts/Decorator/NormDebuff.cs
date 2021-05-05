using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormDebuff : DebuffDecorator
{
    Body buildup;

    public NormDebuff(Body b)
    {
        buildup = b;
    }

    public override int GetDamage()
    {
        return buildup.GetDamage() - 5;
    }

    public override int GetJunkCount()
    {
        return buildup.GetJunkCount() + 1;
    }

}