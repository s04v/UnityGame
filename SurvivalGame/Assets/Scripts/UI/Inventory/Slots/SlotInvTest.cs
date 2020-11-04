using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInvTest : MonoBehaviour
{
    public InventorySlot slot;
    public SlotInvTest test;
    public bool Test;

    private void Update()
    {
        if (Test)
        {
            InventorySlot.SwapItems(slot, test.slot);
        }
    }
}
