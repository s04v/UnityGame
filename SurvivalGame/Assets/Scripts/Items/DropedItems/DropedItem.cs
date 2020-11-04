using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public ItemBase item;
    public int count;

    public DropedItem(ItemBase item, int count)
    {
        this.item = item;
        this.count = count;
    }

    void Start()
    {
        RenderDropedItem();
    }

    void Update()
    {
        
    }

    public void MergeDropedItems(DropedItem dropedItem)
    {
        this.count += dropedItem.count;
    }

    public void RenderDropedItem()
    {
        if (item == null || count == 0)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = item.icon;
            spriteRenderer.enabled = true;
        }
    }
}
