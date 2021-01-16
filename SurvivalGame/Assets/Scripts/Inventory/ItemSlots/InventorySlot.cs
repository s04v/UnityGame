using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Полность рабочий

[System.Serializable]
public class InventorySlot 
{
    [SerializeField]private int count;
    public Item item;

    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            if (count > item.maxStackSize)
            {
                count = item.maxStackSize;
            }
            else if (count <= 0)
            {
                RemoveItem();
            }
        }
    }

    public InventorySlot()
    {
        count = 0;
        item = null;
    }

    public InventorySlot(Item item)
    {
        count = 1;
        this.item = item;
    }

    public InventorySlot(Item item, int count)
    {
        this.count = count;
        this.item = item;
    }

    public static bool IsNull(InventorySlot slot)
    {
        return slot.item == null;
    }

    public bool IsNull()
    {
        return this.item == null;
    }

    public static bool IsFull(InventorySlot slot)
    {
        return slot.count == slot.item.maxStackSize;
    }

    public bool IsFull()
    {
        return this.count == this.item.maxStackSize;
    }

    public static void RemoveItem(InventorySlot slot)
    {
        slot.count = 0;
        slot.item = null;
    }

    public void RemoveItem()
    {
        count = 0;
        item = null;
    }

    public static void SwapItems(InventorySlot slot1, InventorySlot slot2)
    {

        InventorySlot tmp = new InventorySlot(slot1.item, slot1.count);
        slot1.item = slot2.item;
        slot1.count = slot2.count;
        slot2.item = tmp.item;
        slot2.count = tmp.count;
    }

    public void SwapItems(InventorySlot slot)
    {
        InventorySlot tmp = new InventorySlot(this.item, this.count);
        this.item = slot.item;
        this.count = slot.count;
        slot.item = tmp.item;
        slot.count = tmp.count;
    }

    public InventorySlot Copy()
    {
        return new InventorySlot(this.item, this.count);
    }

    public static InventorySlot Copy(InventorySlot slot)
    {
        return new InventorySlot(slot.item, slot.count);
    }
}
