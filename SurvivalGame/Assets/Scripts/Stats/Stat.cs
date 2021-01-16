using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    public float BaseValue { get { return baseValue; } }

    [SerializeField] private float resultValue;
    public float ResultValue { get { return resultValue; } }

    [SerializeField] private List<StatModifier> modifiers;

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
        resultValue = baseValue;
    }

    public Stat() : this(0) { }

    public void AddModifier(StatModifier modifier)
    {
        modifiers.Add(modifier);
        modifiers.Sort(CompareModifierLayer);
        CalculateResultValue();
    }

    public void AddModifiersRange(StatModifier [] modifiersRange)
    {
        modifiers.AddRange(modifiersRange);
        modifiers.Sort(CompareModifierLayer);
        CalculateResultValue();
    }

    private int CompareModifierLayer(StatModifier a, StatModifier b)
    {
        if (a.Layer < b.Layer)
            return -1;
        else if (a.Layer > b.Layer)
            return 1;
        return 0;
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        bool removed = modifiers.Remove(modifier);
        if(removed)
            CalculateResultValue();
        return removed;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool removed = false;

        for (int i = 0; i < modifiers.Count; i++)
        {
            if (modifiers[i].Source == source)
            {
                removed = true;
                modifiers.RemoveAt(i);
            }
        }

        if (removed)
            CalculateResultValue();

        return removed;
    }

    public void CalculateResultValue()
    {
        resultValue = baseValue;
        int layer = modifiers[0].Layer;
        float layerPercent = 0;

        for (int i = 0; i < modifiers.Count; i++)
        {
            StatModifier mod = modifiers[i];

            if (layer != mod.Layer)
            {
                layer = mod.Layer;
                resultValue *= (1 + layerPercent);
                layerPercent = 0;
            }

            if (mod.Type == StatModifierType.flat)
            {
                resultValue += mod.Value;
            }
            else
            {
                layerPercent += mod.Value;
            }
        }
        resultValue *= (1 + layerPercent);
    }
}
