using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventoryContent;
    [SerializeField] private int inventorySize;

    [SerializeField] private InventorySlot[] hotbarContent;
    [SerializeField] private int hotbarSize;

    [SerializeField] private int selectedHotbarSlot;

    private InventorySlot selectedItem;

    public int NumberOfFilledSlots
    {
        get 
        {
            int count = 0;
            for (int i = 0; i < inventorySize; i ++)
            {
                if (inventoryContent[i] != null)
                    count++;
            }
            for (int i = 0; i < hotbarSize; i++)
            {
                if (inventoryContent[i] != null)
                    count++;
            }
            return count;
        }
    }

    public int NumberOfFreeSlots { get { return (inventorySize + hotbarSize) - NumberOfFilledSlots; } }

    [SerializeField] private Canvas UI;

    void Start()
    {}

    public void NextHotbarSlot()
    {
        if (selectedHotbarSlot == hotbarSize)
        {
            selectedHotbarSlot = 0;
            //Ивент смены инвентаря
        }
        else
        {
            selectedHotbarSlot++;
            //Ивент смены инвентаря
        }
    }

    public void PreviosHotbarSlot()
    {
        if (selectedHotbarSlot == 0)
        {
            selectedHotbarSlot = hotbarSize;
            //Ивент смены инвентаря
        }
        else
        {
            selectedHotbarSlot--;
            //Ивент смены инвентаря
        }
    }

    public bool TryToAddItemToInventory(ItemBase item, int count)
    {
        if (item == null || count <= 0) //Проверка не пуст ли предмет и количество больше 0
            return false;
        List<int> list = FindItem(item.id);
        if (item.maxStackSize == 1 || list.Count <= 0)
        {
            //TryToAddItemToInvArray
            // Дописать
            return true;
        }
        else
        {
            foreach (int i in list)
            {
                if (i < hotbarSize)
                {
                    if (hotbarContent[i].count < item.maxStackSize)
                    {
                        int adding = item.maxStackSize - hotbarContent[i].count;
                        if (adding >= count)
                        {
                            hotbarContent[i].count += count;
                            count = 0;
                            // Евент обновления инвенторя
                            return true;
                        }
                        else
                        {
                            hotbarContent[i].count = item.maxStackSize;
                            count -= adding;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (inventoryContent[i - hotbarSize].count < item.maxStackSize)
                    {
                        int adding = item.maxStackSize - inventoryContent[i - hotbarSize].count;
                        if (adding >= count)
                        {
                            inventoryContent[i - hotbarSize].count += count;
                            count = 0;
                            // Евент обновления инвенторя
                            return true;
                        }
                        else
                        {
                            inventoryContent[i - hotbarSize].count = item.maxStackSize;
                            count -= adding;
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            TryToAddItemToInvArray(item, count);
            // Евент обновления инвенторя
            return true;
        }
    }

    public bool TryToAddItemToInvArray(ItemBase item, int count)
    {
        List<int> list = FindFreeItemSlots();
        if (list.Count <= 0)
        {
            return false;
        }

        foreach (int i in list)
        {
            if (i < hotbarSize)
            {
                if (count <= item.maxStackSize)
                {
                    hotbarContent[i].item = item.Copy();
                    hotbarContent[i].count = count;
                    // Евент обновления инвенторя
                    return true;
                }
                else
                {
                    hotbarContent[i].item = item.Copy();
                    hotbarContent[i].count = item.maxStackSize;
                    count -= item.maxStackSize;
                }
            }
            else
            {
                if (count <= item.maxStackSize)
                {
                    inventoryContent[i - hotbarSize].item = item.Copy();
                    inventoryContent[i - hotbarSize].count = count;
                    // Евент обновления инвенторя
                    return true;
                }
                else
                {
                    inventoryContent[i - hotbarSize].item = item.Copy();
                    inventoryContent[i - hotbarSize].count = item.maxStackSize;
                    count -= item.maxStackSize;
                }
            }
        }
        if (count != 0)
        {
            //Что то хуй знает что
            // Евент обновления инвенторя
            return false;
        }
        // Евент обновления инвенторя
        return false;

    }

    public void SelectItem()
    {
    }

    public void ResetInventory() //Пересоздает инвентарь
    {
        inventoryContent = new InventorySlot[inventorySize];
        hotbarContent = new InventorySlot[hotbarSize];
        // Евент обновления инвенторя
    }

    public bool TryToCleanInventorySlot(int numberOfSlot)
    {
        if (numberOfSlot < hotbarSize && numberOfSlot > 0)
        {
            hotbarContent[numberOfSlot].RemoveItem();
            // Евент обновления инвенторя
            return true;
        }
        else if (numberOfSlot > hotbarSize && numberOfSlot < inventorySize + hotbarSize)
        {
            inventoryContent[numberOfSlot].RemoveItem();
            // Евент обновления инвенторя
            return true;
        }
        else
            return false;
    }

    public bool TryToConsumeItemInInventory(int id, int count) //Пытается потратить нужное количество определенного предмета (например для крафинга)
    {
        int countInInventory = GetCountOfItem(id);
        if (countInInventory > count) //Если количество предметов в инвентаре больше нужного то начать отнимать
        {
            List<int> list = FindItem(id);
            foreach (int i in list)
            {
                if (i < hotbarSize)
                {
                    if (hotbarContent[i].count <= count)
                    {
                        count -= hotbarContent[i].count;
                        hotbarContent[i].RemoveItem();
                        if (count == 0)
                            break; 
                    }
                    else
                    {
                        hotbarContent[i].count -= count;
                        break;
                    }
                }
                else
                {
                    if (inventoryContent[i].count <= count)
                    {
                        count -= inventoryContent[i].count;
                        inventoryContent[i].RemoveItem();
                        if (count == 0)
                            break;
                    }
                    else
                    {
                        inventoryContent[i].count -= count;
                        break;
                    }
                }
            }
            // Евент обновления инвенторя
            return true;
        }
        else if (countInInventory == count) //Если количество предметов в инвентаре равное количеству которое нужно потратить то очищает инвентарь от этого предмета
        {
            List<int> list = FindItem(id);
            foreach (int i in list)
            {
                if (i < hotbarSize)
                {
                    hotbarContent[i].RemoveItem();
                }
                else
                {
                    inventoryContent[i - hotbarSize].RemoveItem();
                }
            }
            // Евент обновления инвенторя
            return true;
        }
        else //Если количество предметов в инвентаре меньше нужного то вернуть false
        {
            return false;
        }
    }

    public List<int> FindItem(int itemId) //Список слотов содержащих данный предмет
    {
        List<int> list = new List<int>();
        for (int i = 0; i < hotbarSize; i++)
        {
            if (!hotbarContent[i].IsNull())
            {
                if (hotbarContent[i].item.id == itemId)
                    list.Add(i);
            }
        }
        for (int i = 0; i < inventorySize; i++)
        {
            if (!inventoryContent[i].IsNull())
            {
                if (inventoryContent[i].item.id == itemId)
                    list.Add(i + hotbarSize);
            }
        }

        return list;
    }

    public List<int> FindFreeItemSlots() //Список пустых слотов
    {
        List<int> list = new List<int>();
        for (int i = 0; i < hotbarSize; i++)
        {
            if (inventoryContent[i] == null)
                list.Add(i);
        }
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryContent[i] == null)
                list.Add(i + hotbarSize);
        }
        return list;
    }

    public int GetCountOfItem(int itemId) //Количество данного предмета в инвентаре
    {
        List<int> list = FindItem(itemId);
        int count = 0;
        foreach (int i in list)
        {
            if (i < hotbarSize)
            {
                count += hotbarContent[i].count;
            }
            else
            {
                count += inventoryContent[i].count;
            }
        }
        return count;
    }
}
