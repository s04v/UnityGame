using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatValue
{
    [SerializeField] private Stat maxValue;
    public Stat MaxValue { get {return maxValue; } }

    [SerializeField] private float currentValue;
    public float Value { 
        get { return currentValue; }
        set {
            currentValue = value;
            if (currentValue >= maxValue.ResultValue)
            {
                currentValue = maxValue.ResultValue;
            }
        }
    }

    public StatValue(float maxValueBase, float currentValue)
    {
        maxValue = new Stat(maxValueBase);
        this.currentValue = currentValue;
    }

    public void AddMaxValueModifier(StatModifier modifier)
    {
        maxValue.AddModifier(modifier);
        FixCurrentValue();
    }

    public void AddMaxValueModifiersRange(StatModifier[] modifiersRange)
    {
        maxValue.AddModifiersRange(modifiersRange);
        FixCurrentValue();
    }

    public bool RemoveMaxValueModifier(StatModifier modifier)
    {
        bool removed = maxValue.RemoveModifier(modifier);
        if (removed)
            FixCurrentValue();
        return removed;
    }

    public bool RemoveAllMaxValueModifiersFromSource(object source)
    {
        bool removed = maxValue.RemoveAllModifiersFromSource(source);
        if(removed)
            FixCurrentValue();
        return removed;
        
    }

    protected virtual void FixCurrentValue()
    {
        if (currentValue >= maxValue.ResultValue)
        {
            currentValue = maxValue.ResultValue;
        }
    }
}
