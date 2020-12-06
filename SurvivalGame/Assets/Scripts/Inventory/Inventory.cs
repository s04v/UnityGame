using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IEventListener<InventoryEvent>, IItemContainer
{
    public List<InventorySlot> inventoryContent;
    [SerializeField] private int invetorySize;
    [SerializeField] private int hotbarSize;

    public int InventorySize { get { return invetorySize; } }
    public int HotbarSize { get { return hotbarSize; } }

    public List<InventorySlot> itemsContainer { get { return inventoryContent; } }

    public InventorySlot selectedItem;

    public delegate void UpdateGUI();

    public event UpdateGUI update;

    public bool initialized { get; private set; } = false;

    [SerializeField] private float minDropDistance;
    [SerializeField] private float maxDropDistance;
    [SerializeField] private GameObject dropedItemPrefab;

    [SerializeField] private Collider2D collider2D;

    void Start()
    {
        Initialize();
    }

    void Update()
    { }

    private void OnEnable()
    {
        EventSystem.AddListener<InventoryEvent>(this);
    }

    private void OnDisable()
    {
        EventSystem.RemoveListener<InventoryEvent>(this);
    }

    public void OnInventoryClose()
    {
        Debug.Log("Close inventory");
        FreeSelectedSlot();
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

    /*public void DropItem(int index, ref bool isPressed)(еще не реализовано)
    {
        if (selectedItem.IsNull())
        {
            if (!inventoryContent[index].IsNull())
            {

            }
            else
            {
                return;
            }
        }
        else 
        {
            selectedItem.Count--;
            // Item drop
            update?.Invoke();
        }
    }*/

    /*private IEnumerator ItemDropping(InventorySlot slot, ref bool isPressed) (пока что но хуй его знает как реализовать может придумаю)
    {
        while (!slot.IsNull())
        {
            slot.Count--;
            //drop item
            yield return new WaitForSeconds(1);
        }
    }*/

    public void FreeSelectedSlot()
    {
        if (selectedItem == null)
        {
            return;
        }
        
        AddItemToInventory(selectedItem);
        if (!selectedItem.IsNull())
        {
            DropItem(selectedItem);
        }
        
    }

    public void AddItemToEmptyInventorySlots(ItemBase item, int count)//Добавляет предмет в пустой слот
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

    public void AddItemToEmptyInventorySlots(InventorySlot item)//Добавляет предмет в пустой слот (Работает)
    {
        int emptySlotIndex = FindEmptySlot();
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
                AddItemToEmptyInventorySlots(item, count);
            }
        }
        else
        {
            AddItemToEmptyInventorySlots(item, count);
        }
    }//(Сделать перегрузку для InventorySlot)

    public void AddItemToInventory(InventorySlot item)//Добавляет предмет в инвентарь (Вроде работает)
    {
        if (item.IsNull())
        {
            return;
        }

        List<int> itemList = FindItem(item.item);
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
                AddItemToEmptyInventorySlots(item);
            }
        }
        else
        {
            AddItemToEmptyInventorySlots(item);
        }
        update?.Invoke();
    }//(Сделать перегрузку для InventorySlot)

    public void DropItem(int index)
    {
        if (inventoryContent[index].IsNull())
            return; 
        SpawnDropedItem(index);
        inventoryContent[index].RemoveItem();
        update?.Invoke();
    }

    public void DropItem(InventorySlot inventorySlot)
    {
        if (inventorySlot.IsNull())
            return;
        SpawnDropedItem(inventorySlot);
        inventorySlot.RemoveItem();
        update?.Invoke();
    }

    public void SpawnDropedItem(int index)
    {
        

        Vector2 direction = Math.RandomDirection();
        float distanse = Random.Range(minDropDistance, maxDropDistance);

        RaycastHit2D [] raycastHit = new RaycastHit2D[1];

        if (collider2D.Raycast(direction , raycastHit, distanse + 5) > 0)
        {
            Debug.Log(raycastHit[0].collider.gameObject.name);
            distanse = raycastHit[0].distance;
        }

        Debug.DrawRay(new Vector2(collider2D.bounds.center.x, collider2D.bounds.center.y), direction, Color.green, 7f);



        //RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(collider2D.transform.position.x, collider2D.transform.position.y) + collider2D.offset, direction, distanse);




        /*Debug.Log(raycastHit.collider?.gameObject.name);
        Debug.DrawRay(new Vector2(collider2D.transform.position.x, collider2D.transform.position.y) + collider2D.offset, direction, Color.green, 7f);
        */
        //Debug.Log(raycastHit.collider.name == null);

        GameObject droppedItem = Instantiate(dropedItemPrefab);
        droppedItem.transform.position = transform.position + new Vector3(direction.x + distanse, direction.y + distanse, 0);

        ItemPicker itemPicker = droppedItem.GetComponent<ItemPicker>();
        if (itemPicker == null)
            return;
        Debug.Log(inventoryContent[index].IsNull());
        itemPicker.Item = inventoryContent[index].Copy();

    }

    public void SpawnDropedItem(InventorySlot inventorySlot)
    {

        Vector2 direction = Math.RandomDirection();
        float distanse = Random.Range(minDropDistance, maxDropDistance);

        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, distanse);
        Debug.Log(raycastHit.collider?.gameObject.name);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 0f), direction, Color.green, 2f);

        //Debug.Log(raycastHit.collider.gameObject.name);

        GameObject droppedItem = Instantiate(dropedItemPrefab);
        droppedItem.transform.position = new Vector3(direction.x + distanse, direction.y + distanse, 0);

        ItemPicker itemPicker = droppedItem.GetComponent<ItemPicker>();
        //droppedItem.transform.position = (direction.x + distanse);
        if (itemPicker == null)
            return;

        itemPicker.Item = inventorySlot.Copy();

    }

    public void ClearInventory()
    {
        for (int i = 0; i < invetorySize + hotbarSize; i++)
        {
            inventoryContent[i].RemoveItem();
        }
        selectedItem.RemoveItem();
    }

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
            inventoryContent.Add(new InventorySlot());
        }
        selectedItem = new InventorySlot();
        initialized = true;
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

    public void OnEventTrigger(InventoryEvent eventMessege)
    {
        /*if ()
        { }*/

        switch (eventMessege.eventType)
        {
            case InventoryEventTypes.PickItem:
                AddItemToInventory(eventMessege.inventorySlot);
                break;
            case InventoryEventTypes.OpenInventory:
                //Что нибудь сделаю
                break;
            case InventoryEventTypes.CloseInventory:
                OnInventoryClose();
                break;
        }
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