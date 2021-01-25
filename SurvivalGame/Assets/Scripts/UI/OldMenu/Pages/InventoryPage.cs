using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour, IUIItemContainer
{
    [SerializeField] private List<SlotUI> inventoryUISlots;
    public List<SlotUI> UISlots { get { return inventoryUISlots; } }

    [SerializeField] private SelectedItemSlot selectedItemSlot;

    [SerializeField] private int hoverSlot = -1;

    [SerializeField] private NewInventory inventory;

    [Space]
    [SerializeField] private RectTransform inventoryPlane;
    [SerializeField] private RectTransform hotbarPlane;
    [SerializeField] private RectTransform equipablePlane;
    [Space]
    [SerializeField] private GameObject slotUIPrefab;
    [SerializeField] private GameObject selectedItemSlotPrefab;

    private bool Initialized = false;

    private void Awake()
    {
        hoverSlot = -1;

       /* if (GUIManager.Instance.Player.Inventory == null)
        {
            inventory = GUIManager.Instance.Player.GetComponent<Inventory>();
        }
        else
        {
            inventory = GUIManager.Instance.Player.Inventory;
        }*/
        Initialize();
    }

    private void Update()
    {
        InventoryInput();
    }

    private void OnEnable()
    {
        inventory.inventoryChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        inventory.inventoryChanged -= UpdateUI;
        EventSystem.OnEventTrigger(new InventoryEvent(InventoryEventTypes.CloseInventory, null, 0));
        hoverSlot = -1;
    }

    public void InventoryInput()
    {
        if (Input.GetButtonDown("DropItem"))
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        /*if (!inventory.SelectedItem.IsNull())
        {
            inventory.DropItem(inventory.SelectedItem);
        }
        if (hoverSlot != -1)
        {
            inventory.DropItem(hoverSlot);
        }*/
    }

    public void Initialize()//Создание UI слотов 
    {
        int inventorySize = inventory.inventorySize, hotbarSize = inventory.hotBarSize;
        for (int i = 0; i < hotbarSize; i++)
        {
            GameObject slot = Instantiate(slotUIPrefab, hotbarPlane);
            inventoryUISlots.Add(slot.GetComponent<SlotUI>());
            inventoryUISlots[i].index = i;
            inventoryUISlots[i].name = "slot " + i;
        }
        for (int i = hotbarSize; i < inventorySize + hotbarSize; i++)
        {
            GameObject slot = Instantiate(slotUIPrefab, inventoryPlane);
            inventoryUISlots.Add(slot.GetComponent<SlotUI>());
            inventoryUISlots[i].index = i;
            inventoryUISlots[i].name = "slot " + i;
        }
        selectedItemSlot = Instantiate(selectedItemSlotPrefab, transform).GetComponent<SelectedItemSlot>();
        Initialized = true;
    }

    public void OnSlotHover(int index)//При наведении на слот
    {
        hoverSlot = index;
    }

    public void OnSlotIdle(int index)//При снятии фокуса со слота
    {
        hoverSlot = -1;
    }

    public void OnLeftSlotClicked(int index)
    {
        inventory.OnLeftSlotClick(index);
    }

    public void OnRightSlotClicked(int index)
    {
        inventory.OnRightSlotClick(index);
    }

    public void UpdateUI()
    {
        if (inventory.initialized && Initialized)
        {
            for (int i = 0; i < inventoryUISlots.Count; i++)
            {
                inventoryUISlots[i].UpdateItem(inventory.itemsContainer[i]);
            }
        }

        selectedItemSlot.UpdateItem(inventory.SelectedItem);
    }
}