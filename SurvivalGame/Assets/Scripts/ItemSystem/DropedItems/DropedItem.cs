using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour, IPickable
{
    [SerializeField] private InventorySlot inventorySlot;

    public Sprite Icon
    { get 
        {
            if (inventorySlot == null)
            {
                return null;
            }
            return inventorySlot.item.icon;
        }
        set { }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnPick(Player player)
    {
        player.inventory.AddItemToInventory(inventorySlot);
        if (inventorySlot.Count == 0)
            Destroy(gameObject);
    }
}
