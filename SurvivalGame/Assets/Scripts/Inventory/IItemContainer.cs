﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
    List<InventorySlot> itemsContainer { get; }
}
