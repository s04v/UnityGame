using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIItemContainer
{
    List<SlotUI> UISlots { get; }


    void OnSlotHover(int index);
    void OnSlotIdle(int index);
    void OnLeftSlotClicked(int index);
    void OnRightSlotClicked(int index);
}
