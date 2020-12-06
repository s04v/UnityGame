using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotUI : MonoBehaviour
{
    public int index;
    [SerializeField] private Image icon;
    [SerializeField] private Text count;
    private IUIItemContainer targetContainer;

    private void Start()
    {
        targetContainer = GetComponentInParent<IUIItemContainer>();
    }

    public void OnPointerEnter()
    {
        targetContainer.OnSlotHover(index);
    } 

    public void OnPointerExit()
    {
        targetContainer.OnSlotIdle(index);
    }

    public void OnLeftClicked()
    {
        targetContainer.OnLeftSlotClicked(index);
    }

    public void OnRightClicked()
    {
        targetContainer.OnRightSlotClicked(index);
    }

    public void UpdateItem(InventorySlot item)
    {
        if (item.item != null)
        {
            icon.sprite = item.item.icon;
            icon.enabled = true;
            if (item.item.maxStackSize > 1)
            {
                count.text = item.Count.ToString();
                count.enabled = true;
            }
            else
            {
                count.enabled = false;
            }
        }
        else
        {
            icon.enabled = false;
            count.enabled = false;
        }
    }


}
