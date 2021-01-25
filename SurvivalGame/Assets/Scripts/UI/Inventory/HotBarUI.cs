using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarUI : MonoBehaviour
{
    [SerializeField] private List<SlotUI> slots;
    [SerializeField] private NewInventory inventory;

    private void Awake()
    {
        slots.AddRange(GetComponentsInChildren<SlotUI>());
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].index = i;
        }
        //inventory.inventoryChanged += UpdateUI;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        inventory.inventoryChanged += UpdateUI;
    }

    private void OnDisable()
    {
        inventory.inventoryChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        foreach (SlotUI slot in slots)
        {
            slot.UpdateItem(inventory.itemsContainer[slot.index]);
        }
    }
}
