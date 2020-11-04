using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> inventoryContent;
    [SerializeField] private int invetorySize;
    [SerializeField] private int hotbarSize;

    public InventorySlot selectedItem;

    public delegate void UpdateGUI();

    public event UpdateGUI update;

    public bool Test;

    void Start()
    {
        Initialize();
        update?.Invoke();
    }

    private void Update()
    {
        if (Test)
        {
            update?.Invoke();
            Test = !Test;
        }
    }

    public void OnLeftClickSlot(int index)
    {
        if (selectedItem.IsNull() && inventoryContent[index].IsNull())
        {
            return;
        }     
        else if(inventoryContent[index].item == selectedItem.item && !inventoryContent[index].IsFull())
        {
            int countToAdd = inventoryContent[index].item.maxStackSize - inventoryContent[index].Count;
            if (countToAdd >= selectedItem.Count)
            {
                inventoryContent[index].Count += selectedItem.Count;
                selectedItem.RemoveItem();
            }
            else
            {
                selectedItem.Count -= countToAdd;
                inventoryContent[index].Count += countToAdd;
            }
        }
        else
        {
            selectedItem.SwapItems(inventoryContent[index]);
        }
        update?.Invoke();
    }

    public void OnRightClickSlot(int index)
    {
        //для оптимизации вместо множественных вызовов функций сделать это по 1 разу
        if ((selectedItem.IsNull() && inventoryContent[index].IsNull()) || (inventoryContent[index].item == selectedItem.item && inventoryContent[index].IsFull()))
        {
            return;
        }
        else if (inventoryContent[index].item == selectedItem.item && !inventoryContent[index].IsFull())
        {
            inventoryContent[index].Count++;
            selectedItem.Count--;
            update?.Invoke();
        }
        else if (selectedItem.IsNull())
        {
            int itemCount = inventoryContent[index].Count / 2 + inventoryContent[index].Count % 2;
            selectedItem = inventoryContent[index].Copy();
            selectedItem.Count = itemCount;
            inventoryContent[index].Count -= itemCount;   
            update?.Invoke();
        }
        else
        {
            inventoryContent[index] = selectedItem.Copy();
            inventoryContent[index].Count = 1;
            selectedItem.Count--;
            update?.Invoke();
        }
    }

    public void AddItemToInventoryArray(ItemBase item, int count)//Добавляет предмет в пустой слот
    {
        List<int> emptySlotsList = FindEmptySlots();
        if (emptySlotsList.Count == 0)
            return;
        else
        {
            foreach (int i in emptySlotsList)
            {
                inventoryContent[i].item = item.Copy();

                if (count <= item.maxStackSize)
                {
                    inventoryContent[i].Count = count;
                    update?.Invoke();
                    return;
                }
                else
                {
                    inventoryContent[i].Count = item.maxStackSize;
                    count -= item.maxStackSize;
                }
            }
        }

        update?.Invoke();
    } //(Сделать перегрузку для InventorySlot)

    public void AddItemToInventoryArray(InventorySlot item)//Добавляет предмет в пустой слот (Работает)
    {
        int emptySlotIndex = FindEmptySlot();
        Debug.Log("Empty slot index " + emptySlotIndex);
        if (emptySlotIndex == -1)
            return;
        else
        {
            inventoryContent[emptySlotIndex] = item.Copy();
            item.Count = 0;
            update?.Invoke();
        }
    }

    public void AddItemToInventory(ItemBase item, int count)//Добавляет предмет в инвентарь
    {
        if (item == null || count == 0)
            return;

        List<int> itemList = FindItem(item);
        if (itemList.Count > 0 && item.maxStackSize > 1)
        {
            foreach (int i in itemList)
            {
                if (inventoryContent[i].Count < item.maxStackSize)
                {
                    int countToAdd = item.maxStackSize - inventoryContent[i].Count;
                    if (countToAdd >= count)
                    {
                        countToAdd = count;
                        inventoryContent[i].Count += countToAdd;
                        update?.Invoke();
                        return;
                    }
                    else
                    {
                        count -= countToAdd;
                        inventoryContent[i].Count += countToAdd;
                    }
                }
                else
                {
                    continue;
                }
            }
            if (count > 0)
            {
                AddItemToInventoryArray(item, count);
            }
        }
        else
        {
            AddItemToInventoryArray(item, count);
        }
    }//(Сделать перегрузку для InventorySlot)

    public void AddItemToInventory(InventorySlot item)//Добавляет предмет в инвентарь (Вроде работает)
    {
        if (item.IsNull())
        {
            return;
        }

        List<int> itemList = FindItem(item.item);
        Debug.Log(itemList.Count);
        if (itemList.Count > 0 && item.item.maxStackSize > 1)
        {

            foreach (int i in itemList)
            {
                if (!inventoryContent[i].IsFull())
                {
                    int countToAdd = item.item.maxStackSize - inventoryContent[i].Count;
                    if (countToAdd >= item.Count)
                    {
                        countToAdd = item.Count;
                        Debug.Log("Count to add " + countToAdd);
                        inventoryContent[i].Count += countToAdd;
                        item.Count = 0;
                        update?.Invoke();
                        return;
                    }
                    else
                    {
                        item.Count -= countToAdd;
                        inventoryContent[i].Count += countToAdd;
                    }
                }
                else
                {
                    continue;
                }
            }
            if (item.Count > 0)
            {
                AddItemToInventoryArray(item);
            }
        }
        else
        {
            AddItemToInventoryArray(item);
        }
    }//(Сделать перегрузку для InventorySlot)

    public void ResetInventory()//Сбрасывает инвентарь
    {
        inventoryContent.Clear();
        selectedItem = null;
        Initialize();
    }

    public void Initialize()//Инициализация инвенитаря
    {
        for (int i = 0; i < invetorySize + hotbarSize; i++)
        {
            Debug.Log("Create slot " + i);
            inventoryContent.Add(new InventorySlot());
        }
        selectedItem = new InventorySlot();
        update?.Invoke();
    }

    public List<int> FindItem(int itemId) //Список слотов содержащих данный предмет
    {
        List<int> list = new List<int>();
        for (int i = 0; i < inventoryContent.Count; i++)
        {
            if (!inventoryContent[i].IsNull())
            {
                if (inventoryContent[i].item.id == itemId)
                    list.Add(i);
            }
        }
        return list;
    }

    public List<int> FindItem(ItemBase item) //Список слотов содержащих данный предмет
    {
        List<int> list = new List<int>();
        for (int i = 0; i < inventoryContent.Count; i++)
        {
            if (!inventoryContent[i].IsNull())
            {
                if (inventoryContent[i].item.id == item.id)
                    list.Add(i);
            }
        }
        return list;
    }

    public List<int> FindEmptySlots() //Список пустых слотов (Работет)
    {
        List<int> list = new List<int>();

        for (int i = 0; i < inventoryContent.Count; i++)
        {
            if (inventoryContent[i].IsNull())
                list.Add(i);
        }
        return list;
    }

    public List<int> FindEmptySlots(int limit)//Список пустых слотов (максимально может найти limit слотов)(работает) 
    {
        List<int> list = new List<int>();

        for (int i = 0; i < inventoryContent.Count || list.Count < limit; i++)
        {
            if (inventoryContent[i].IsNull())
                list.Add(i);
        }
        return list;
    }

    public int FindEmptySlot()//Находит первый пустой слот(работает)
    {
        for (int i = 0; i < inventoryContent.Count; i++)
        {
            if (inventoryContent[i].IsNull())
                return i;
        }
        return -1;
    }

    public int GetCountOfItem(int itemId) //Количество данного предмета в инвентаре
    {
        List<int> list = FindItem(itemId);
        int count = 0;
        foreach (int i in list)
        {
            count += inventoryContent[i].Count;
        }
        return count;
    }

    public int GetCountOfItem(ItemBase item) //Количество данного предмета в инвентаре
    {
        List<int> list = FindItem(item);
        int count = 0;
        foreach (int i in list)
        {
            count += inventoryContent[i].Count;
        }
        return count;
    }


}










































/* Может когда нибудь переделаю
 * public void AddItemToInventoryArray(InventorySlot item)
    {
        List<int> emptySlotsList = FindEmptySlots();
        Debug.Log("Empty slots count " + emptySlotsList.Count);
        if (emptySlotsList.Count == 0)
            return;
        else
        {
            foreach (int i in emptySlotsList)
            {
                inventoryContent[i] = item.Copy();            
            }
        }
    }*/