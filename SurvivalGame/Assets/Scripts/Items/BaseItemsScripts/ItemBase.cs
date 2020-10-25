using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tests", menuName = "inventory/items")]
public class ItemBase : ScriptableObject
{
    public int id;
    public string title;
    public string description;
    public int maxStackSize;
    public Sprite icon;

    public virtual ItemBase Copy()
    {
        ItemBase clone = Instantiate<ItemBase>(this);
        return clone;
    }
}

