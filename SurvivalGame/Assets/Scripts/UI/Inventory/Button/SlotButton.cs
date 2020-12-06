using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SlotButton : Button
{
    [SerializeField]private SlotUI slot;

    [SerializeField]private InventorySlotEvent onRightClickEvent;
    [SerializeField]private InventorySlotEvent onLeftClickEvent;
    [SerializeField]private InventorySlotEvent onMiddleClickEvent;

    [SerializeField] private InventorySlotEvent onPointerEnter;
    [SerializeField] private InventorySlotEvent onPointerExit;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable)
            return;
        onPointerEnter?.Invoke(slot.index);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable)
            return;
        onPointerExit?.Invoke(slot.index);
    }

    public override void OnLeftClick()
    {
        if (!interactable)
            return;
        onLeftClickEvent?.Invoke(slot.index);
    }

    public override void OnRightClick()
    {
        if (!interactable)
            return;
        onRightClickEvent?.Invoke(slot.index);
    }

    public override void OnMiddleClick()
    {
        if (!interactable)
            return;
        onMiddleClickEvent?.Invoke(slot.index);
    }


}

[System.Serializable]
public class InventorySlotEvent : UnityEvent<int> { }
