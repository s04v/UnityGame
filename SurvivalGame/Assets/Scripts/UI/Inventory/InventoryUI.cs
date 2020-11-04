using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<SlotUI> Slots;

    [SerializeField] private Inventory inventory;

    [SerializeField] private RectTransform inventoryPlane;
    [SerializeField] private RectTransform hotbarPlane;

    [SerializeField]private SelectedItemSlot selectedItem;

   /* private void Awake()
    {
        Slots.AddRange(hotbarPlane.transform.GetComponentsInChildren<SlotUI>());
        Slots.AddRange(inventoryPlane.transform.GetComponentsInChildren<SlotUI>());
        UpdateUI();
    }

    public void UpdateSelectedItemUI()
    {
        selectedItem.UpdateItem(inventory.selectedItem);
    }

    public void UpdateUI(List<int> list)
    {
        foreach (int i in list)
        {
            if (i < inventory.hotbarSize)
                Slots[i].UpdateItem(inventory.hotbarContent[i]);
            else
                Slots[i].UpdateItem(inventory.hotbarContent[i - inventory.hotbarSize]);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (i < inventory.hotbarSize)
                Slots[i].UpdateItem(inventory.hotbarContent[i]);
            else
                Slots[i].UpdateItem(inventory.inventoryContent[i - inventory.hotbarSize]);
        }

        selectedItem.UpdateItem(inventory.selectedItem);
    }*/
}
