using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffDecorator : Body
{
    public abstract override int GetDamage();
    public abstract override int GetJunkCount();
}
