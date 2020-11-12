using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotButton : Button
{
    [SerializeField]private SlotUI slot;

    [SerializeField]private ClickEvent onRightClickEvent;
    [SerializeField]private ClickEvent onLeftClickEvent;
    [SerializeField]private ClickEvent onMiddleClickEvent;

    void Start()
    {
        
    }

    public override void OnLeftClick()
    {
        Debug.Log("Spierdalaj");
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
public class ClickEvent : UnityEvent<int> { }
