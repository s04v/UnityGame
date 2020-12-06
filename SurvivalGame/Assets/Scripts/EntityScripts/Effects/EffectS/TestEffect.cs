using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestEffect : BaseEffect
{
    /*public TestEffect()
    {
        base();
    }*/
    public TestEffect(IEntity entity) : base(entity)
    { }

    public TestEffect(IEntity entity, int duration) : base(entity, duration)
    { }

    public TestEffect(IEntity entity, int duration, int stackCount) : base(entity, duration, stackCount)
    { }
}
   


