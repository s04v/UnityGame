using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataBase : Singleton<DataBase>
{
    public ItemsDataBase itemsDataBase;

    protected override void Awake()
    {
        base.Awake();
    }

    public Item GetItemByID(int ID)
    {
        return itemsDataBase.allItems.FirstOrDefault(i => i.id == ID);
        /*foreach (Item item in itemsDataBase.allItems)
        {
            if (item.id == ID)
                return item;
        }
        return null;*/
    }

    /*public static Item GetItemByID(int ID)
    {
        return Instance.itemsDataBase.allItems.FirstOrDefault(i => i.id == ID);
    }*/
}
