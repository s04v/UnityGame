using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffect
{
    [SerializeField] protected IEntity entity;
    public IEntity Entity { get { return entity; } }

    [SerializeField] static protected EffectScriptableObject effectData;
    public EffectScriptableObject EffectScriptableObject { get { return effectData; } }

    [SerializeField] protected int stackCount;
    public int StackCount { get { return stackCount; } 
        set 
        {
            if (value <= effectData.MaxStackCount)
            {
                stackCount = effectData.MaxStackCount;
            }
            else 
            {
                stackCount = value;
            }
        }
    }

    [SerializeField] protected float duration;
    public float Duration { get { return duration; } set { duration = value; } }

    //Конструкторы
    #region
    public BaseEffect(IEntity entity)
    {
        if (effectData == null)
        {
            effectData = Resources.Load<EffectScriptableObject>(this.GetType().ToString());
        }

        this.entity = entity;
        this.duration = effectData.DefaultDuration;
        this.StackCount = 1;
    }

    public BaseEffect(IEntity entity, float duration)
    {
        if (effectData == null)
        {
            effectData = Resources.Load<EffectScriptableObject>(this.GetType().ToString());
        }

        this.entity = entity;
        this.duration = duration;
        this.StackCount = 1;
    }

    public BaseEffect(IEntity entity, float duration, int stackCount)
    {
        if (effectData == null)
        {
            effectData = Resources.Load<EffectScriptableObject>(this.GetType().ToString());
        }

        this.entity = entity;
        this.duration = duration;
        this.StackCount = stackCount;
    }
    #endregion

    virtual public void OnEffectDispel()
    {
       
    }

    virtual public void OnEffectEnd()
    {
        
    }

    virtual public void OnEffectGive()
    {
        
    }

    virtual public void OnEffectTick()
    {
        if (effectData.EffectDurableType == EffectDurableType.Durable)
        {
            duration -= Time.deltaTime;
        }
    }

    virtual public void StackDegreesed()
    {
    
    }

    virtual public void StackIncreesed()
    {
     
    }
}



