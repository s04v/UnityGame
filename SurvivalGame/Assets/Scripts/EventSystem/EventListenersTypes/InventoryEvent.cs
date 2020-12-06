using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryEventTypes {PickItem, OpenInventory, CloseInventory};

public struct InventoryEvent : IEventStruct
{
    public InventoryEventTypes eventType;

    public InventorySlot inventorySlot;

    public int inventoryIndex;


    public InventoryEvent(InventoryEventTypes eventType, InventorySlot inventorySlot, int inventoryIndex)
    {
        this.eventType = eventType;
        this.inventorySlot = inventorySlot;
        this.inventoryIndex = inventoryIndex;
    }

    public void Trigger()
    {
        EventSystem.OnEventTrigger(this);
    }
}
