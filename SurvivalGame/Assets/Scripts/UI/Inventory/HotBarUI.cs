using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarUI : MonoBehaviour
{
    [SerializeField] private List<SlotUI> slots;
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        slots.AddRange(GetComponentsInChildren<SlotUI>());
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].index = i;
        }
        inventory.update += UpdateUI;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        foreach (SlotUI slot in slots)
        {
            slot.UpdateItem(inventory.inventoryContent[slot.index]);
        }
    }
}
