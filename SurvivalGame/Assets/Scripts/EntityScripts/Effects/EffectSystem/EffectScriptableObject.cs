using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType { Positive, Negative, Neutral };
public enum EffectStackType { NotStakable, Laying, Stackable, Renewable };
public enum EffectDurableType { Durable, NotDurable }

[CreateAssetMenu(fileName = "Effects", menuName = "Effects")]
public class EffectScriptableObject : ScriptableObject
{
    [SerializeField] private string displayName;
    public string DisplayName { get { return displayName; } }

    [SerializeField] private string description;
    public string Description { get {return description; } }

    [SerializeField] private Sprite icon;
    public Sprite Icon { get { return icon; } }

    [SerializeField] private EffectType effectType;
    public EffectType EffectType { get { return effectType; } }

    [SerializeField] private EffectStackType effectStackType;
    public EffectStackType EffectStackType { get { return effectStackType; } }

    [SerializeField] private int maxStackCount;
    public int MaxStackCount { get { return maxStackCount; } }

    [SerializeField] private EffectDurableType effectDurableType;
    public EffectDurableType EffectDurableType { get { return effectDurableType; } }

    [SerializeField] private float defaultDuration;
    public float DefaultDuration { get { return defaultDuration; } }
}
