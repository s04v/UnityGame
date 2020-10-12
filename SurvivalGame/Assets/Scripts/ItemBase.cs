using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase
{
    public int id;
    public int count;
    public string title;
    public Sprite icon;

    public ItemBase(int id, string title, Sprite icon)
    {
    
    }

    public virtual void OnRightClick()
    {
        if (CanAltUseItem()) { }

    }

    public virtual void OnLeftCLick()
    {
        if (CanMainUseItem()) { }
    }

    public virtual void MainFunctionUse()
    { }

    public virtual void AltFunctionUse()
    { }

    public virtual bool CanMainUseItem()
    {
        return true;
    }

    public virtual bool CanAltUseItem()
    {
        return true;
    }

    public virtual void InInventory()
    { }

    public virtual void OnHitNPC()
    { }

    public virtual void ConsumeItem()
    {
        this.count--;
    }

    public virtual void ConsumeOtherItem(ItemBase item)
    {
        item.count--;
    }

}
