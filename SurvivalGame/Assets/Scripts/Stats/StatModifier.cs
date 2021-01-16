using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModifierType {flat, Percent}

[System.Serializable]
public class StatModifier
{
    [SerializeField] private float value;
    public float Value { get { return value; } }

    [SerializeField] private int layer;
    public int Layer { get { return layer; } }

    [SerializeField] private StatModifierType type;
    public StatModifierType Type { get { return type; } }

    [SerializeField] private object source;
    public object Source { get { return source; } }

    

    public StatModifier(float value, int layer, StatModifierType type, object source)
    {
        this.value = value;
        this.layer = layer;
        this.type = type;
        this.source = source;
    }

    public StatModifier(float value, int layer, StatModifierType type) : this(value, layer, type, null) { }

    public StatModifier(float value, int layer, object source) : this(value, layer, StatModifierType.flat, source) { }

    public StatModifier(float value, int layer) : this(value, layer, StatModifierType.flat, null) { }

    public StatModifier(float value) : this(value, 0, StatModifierType.flat, null) { }
}
