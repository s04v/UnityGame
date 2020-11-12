using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public InventorySlot item;
    public Inventory inventory;

    void Start()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }
        inventory = collider.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItemToInventory(item);
            Object.Destroy(gameObject);
        }
        //Pick(Item.TargetInventoryName);
    }
}
