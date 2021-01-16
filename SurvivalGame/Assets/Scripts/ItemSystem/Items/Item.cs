using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Assets/Items/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string title;
    [TextArea]
    public string description;
    public int maxStackSize;
    public Sprite icon;
}
