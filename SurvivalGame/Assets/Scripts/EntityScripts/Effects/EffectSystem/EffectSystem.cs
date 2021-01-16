using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectSystem : MonoBehaviour
{
    [SerializeField] private List<BaseEffect> activeEffectsList = new List<BaseEffect>();

    void Start()
    {
        //activeEffectsList.Add(new TestEffect(null, 5));
        TestEffect effect = new TestEffect(null);
        AddEffect(effect);
        Debug.Log(activeEffectsList.Count);
        TestEffect effect2 = new TestEffect(null);
        AddEffect(effect2);
        Debug.Log(activeEffectsList.Count);
    }

    void Update()
    {
        for (int i = 0; i < activeEffectsList.Count; i++)
        {
            BaseEffect effect = activeEffectsList[i];
            effect.OnEffectTick();
            if (effect.Duration <= 0)
            {
                effect.OnEffectEnd();
                activeEffectsList.RemoveAt(i);
            }
        }
    }

    public void AddEffect(BaseEffect effect)
    {
        Debug.Log(effect.EffectScriptableObject.DisplayName);
        switch (effect.EffectScriptableObject.EffectStackType)
        {
            case EffectStackType.NotStakable:
                {
                    BaseEffect targetEffect = FindEffect(effect);
                    if (targetEffect != null)
                    {
                        targetEffect.Duration = effect.Duration;
                    }
                    else
                    {
                        activeEffectsList.Add(effect);
                    }
                }
                break;
            case EffectStackType.Laying:
                activeEffectsList.Add(effect);
                break;
            case EffectStackType.Stackable:
                {
                    BaseEffect targetEffect = FindEffect(effect);
                    if (targetEffect != null)
                    {
                        targetEffect.StackCount += effect.StackCount;
                        targetEffect.Duration = effect.Duration;
                        targetEffect.StackIncreesed();
                    }
                    else
                    {
                        activeEffectsList.Add(effect);
                    }
                }
                break;
            case EffectStackType.Renewable:
                {
                    BaseEffect targetEffect = FindEffect(effect);
                    if (targetEffect != null)
                    {
                        targetEffect.Duration = effect.Duration;
                    }
                    else
                    {
                        activeEffectsList.Add(effect);
                    }    
                }
                break;
        }        
    }

    public void DispellEffect(string name)
    {
        BaseEffect effect = FindEffect(name);
        if (effect != null)
        {
            effect.OnEffectDispel();
            activeEffectsList.Remove(effect);
        }
    }

    public void DispellEffect(BaseEffect effect)
    {
        BaseEffect targetEffect = FindEffect(effect);
        if (effect != null)
        {
            targetEffect.OnEffectDispel();
            activeEffectsList.Remove(targetEffect);
        }
    }

    public BaseEffect FindEffect(BaseEffect effectToFind)
    {
        foreach (BaseEffect effect in activeEffectsList)
        {
            if (effect.EffectScriptableObject == effectToFind.EffectScriptableObject)
            {
                return effect;
            }
        }

        return null;
    }

    public BaseEffect FindEffect(string name)
    {
        foreach (BaseEffect effect in activeEffectsList)
        {
            if (effect.EffectScriptableObject.DisplayName == name)
            {
                return effect;
            }
        }

        return null;
    }
}
