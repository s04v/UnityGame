using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDataBase", menuName = "DataBases/ItemsDataBase")]
public class ItemsDataBase : ScriptableObject
{
    public List<Item> allItems;
}
