using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    private List<ItemBase> itemsDB = new List<ItemBase>();

    public void Awake()
    {
        BuildItemDataBase();
    }

    public ItemBase GetItem(int id)
    {
        return itemsDB.Find(ItemBase => ItemBase.id == id);
    }

    public ItemBase GetItem(string itemName)
    {
        return itemsDB.Find(ItemBase => ItemBase.title == itemName);
    }

    void BuildItemDataBase()
    {
        itemsDB = new List<ItemBase>
        {
            //Items
        };
    }
}
