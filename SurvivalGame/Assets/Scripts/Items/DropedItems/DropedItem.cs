using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ItemPicker itemPicker;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemPicker = GetComponent<ItemPicker>();
        UpdateSprite();
        itemPicker.update += UpdateSprite;
    }

    public void UpdateSprite()
    {
        spriteRenderer.sprite = itemPicker.Item.item.icon;
    }
}
