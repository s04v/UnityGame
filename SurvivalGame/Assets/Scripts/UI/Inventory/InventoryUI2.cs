using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI2 : MonoBehaviour
{
    [SerializeField] private List<SlotUI> slots;
    [SerializeField] private SelectedItemSlot selectedItemSlot;

    [SerializeField] private Inventory inventory;

    [SerializeField] private RectTransform inventoryPlane;
    [SerializeField] private RectTransform hotbarPlane;

    public bool Test;


    private void Start()
    {
        slots.AddRange(hotbarPlane.transform.GetComponentsInChildren<SlotUI>());
        slots.AddRange(inventoryPlane.transform.GetComponentsInChildren<SlotUI>());
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].index = i;
        }
        inventory.update += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Test)
        {
            UpdateUI();
            Test = !Test;
        }
    }

    public void OnLeftSlotClicked(int index)
    {
        inventory.OnLeftClickSlot(index);
    }

    public void OnRightSlotClicked(int index)
    {
        inventory.OnRightClickSlot(index);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].UpdateItem(inventory.inventoryContent[i]);
        }

        selectedItemSlot.UpdateItem(inventory.selectedItem);
    }
}
