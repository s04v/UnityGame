using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour, IItemContainer
{
    [SerializeField] List<InventorySlot> inventoryContent;
    public List<InventorySlot> itemsContainer { get { return inventoryContent; } }

    [SerializeField] private InventorySlot selectedItem;
    public InventorySlot SelectedItem { get { return selectedItem; }
        set
        {
            selectedItem = value;
        }
    }

    public int selectedSlot;

    [Header("Inventory properties:")]
    public int inventorySize;
    public int hotBarSize;

    public bool initialized = false;

    public delegate void InventoryChanged();
    public event InventoryChanged inventoryChanged;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < inventorySize + hotBarSize; i++)
        {
            inventoryContent.Add(new InventorySlot());
        }
        selectedItem = new InventorySlot();

        initialized = true;

        inventoryChanged?.Invoke();
    }

    public void OnLeftSlotClick(int index) //переписать
    {
        if (selectedItem.IsNull() && inventoryContent[index].IsNull())
            return;

        if (selectedItem.IsNull() || inventoryContent[index].IsNull() || selectedItem.item.id != inventoryContent[index].item.id || inventoryContent[index].IsFull() || selectedItem.IsFull())
        {
            selectedItem.SwapItems(inventoryContent[index]);
        }
        else
        {
            inventoryContent[index].MergeSlots(selectedItem);
        }
        
        inventoryChanged?.Invoke();
    }

    public void OnRightSlotClick(int index)
    {
        if ((selectedItem.IsNull() && inventoryContent[index].IsNull()) || (inventoryContent[index].item?.id == selectedItem.item?.id && inventoryContent[index].IsFull()))
            return;

        if (inventoryContent[index].item == selectedItem.item && !inventoryContent[index].IsFull())
        {
            inventoryContent[index].Count++;
            selectedItem.Count--;
        }
        else if (selectedItem.IsNull())
        {
            int itemCount = inventoryContent[index].Count / 2 + inventoryContent[index].Count % 2;
            selectedItem = inventoryContent[index].Copy();
            selectedItem.Count = itemCount;
            inventoryContent[index].Count -= itemCount;
        }
        else
        {
            inventoryContent[index] = selectedItem.Copy();
            inventoryContent[index].Count = 1;
            selectedItem.Count--;
        }

        inventoryChanged?.Invoke();
    }

    public void NextSlot()
    {
        if (selectedSlot == hotBarSize - 1)
        {
            selectedSlot = 0;
        }
        selectedSlot++;
    }

    public void PreviosSlot()
    {
        if (selectedSlot == 0)
        {
            selectedSlot = hotBarSize - 1;
        }
        selectedSlot--;
    }

    public void Use(PlayerPrePreAlpha player)
    {
        Debug.Log("Ok");
        if (inventoryContent[selectedSlot].IsNull())
        {
            return;
        }
        if (inventoryContent[selectedSlot].item is UsableItem)
            (inventoryContent[selectedSlot].item as UsableItem).OnUse(player);
    }

    public void AddItemToInventory(InventorySlot item)
    {
        if (item.IsNull() || item.item.id < 0)
        {
            return;
        }

        if (item.item.maxStackSize == 1)
        {
            AddItemToEmptySlot(item);
        }
        else
        {
            List<InventorySlot> inventorySlots = FindItemsByID(item.item.id);

            if (inventorySlots.Count > 0)
            {
                bool changed = false;
                foreach (InventorySlot inventorySlot in inventorySlots)
                {
                    if (!inventorySlot.IsFull())
                    {
                        changed = true;

                        inventorySlot.MergeSlots(item);

                        if (item.IsNull())
                            break;
                    }
                }

                if (item.Count > 0)
                {
                    AddItemToEmptySlot(item);
                }
                else
                {
                    if (changed)
                        inventoryChanged?.Invoke();
                }

            }
            else
            {
                AddItemToEmptySlot(item);
            }
        }
    }

    private void AddItemToEmptySlot(InventorySlot item)
    {
        InventorySlot inventorySlot = FindEmptySlot();

        if (inventorySlot == null)
            return;

        inventorySlot.Copy(item);
        item.RemoveItem();

        inventoryChanged?.Invoke();
    }

    public InventorySlot FindItemByID(int ID)
    {
        if (ID < 0)
            return null;
        foreach (InventorySlot inventorySlot in inventoryContent)
        {
            if (!inventorySlot.IsNull() && inventorySlot.item.id == ID)
            {
                return inventorySlot;
            }
        }

        return null;
    }

    public List<InventorySlot> FindItemsByID(int ID)
    {
        if (ID < 0)
            return null;

        List<InventorySlot> inventorySlots = new List<InventorySlot>();

        foreach (InventorySlot inventorySlot in inventoryContent)
        {
            if (!inventorySlot.IsNull() && inventorySlot.item.id == ID)
            {
                inventorySlots.Add(inventorySlot);
            }
        }

        return inventorySlots;
    }

    public InventorySlot FindEmptySlot()
    {
        foreach (InventorySlot inventorySlot in inventoryContent)
        {
            if (inventorySlot.IsNull())
            {
                return inventorySlot;
            }
        }

        return null;
    }

    public List<InventorySlot> FindEmptySlots()
    {
        List<InventorySlot> emptySlots = new List<InventorySlot>();

        foreach (InventorySlot inventorySlot in inventoryContent)
        {
            if (inventorySlot.IsNull())
            {
                emptySlots.Add(inventorySlot);
            }
        }

        return emptySlots;
    }

    public int FindIndexWithItemID(int ID)
    {
        if (ID < 0)
            return -1;

        for (int i = 0; i < inventorySize + hotBarSize; i++)
        {
            if (!inventoryContent[i].IsNull() && inventoryContent[i].item.id == ID)
                return i;
        }

        return -1;
    }
}
