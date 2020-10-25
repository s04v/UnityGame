using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot : MonoBehaviour
{
    public int id;
    public int count;
    [SerializeField]public ItemBase item;
    [SerializeField]private Image icon;
    [SerializeField] private Text text;
    [SerializeField]private Sprite emptySlot;

    private void Start()
    {
        RenderItem(this.item);
    }

    public static bool IsNull(InventorySlot slot)
    {
        return slot.item == null;
    }

    public bool IsNull()
    {
        return this.item == null;
    }

    public void AddItem() { }

    public void RemoveItem()
    {
        count = 0;
        item = null;
    }

    public void RenderItem(ItemBase item)
    {
        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            if (item.maxStackSize > 1)
            {
                text.text = count.ToString();
                text.enabled = true;
            }
            else
            {
                text.enabled = false;
            }
        }
        else
        {
            icon.sprite = emptySlot;
            icon.enabled = true;
            text.enabled = false;
        }
    }
}
