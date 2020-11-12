using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CustomCursor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite normalCursor;
    public Sprite aimCursor;
    public Sprite actomCursor;

    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject selectedSlotUI;

    [SerializeField] private SelectedItemSlot selectedItemSlot;

    [Space]
    [SerializeField] private Vector2 offset;

    private void Start()
    {
        //Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory.update += UpdateSelectedSlotUI;
        
    }

    void FixedUpdate()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos + offset;
    }

    public void UpdateSelectedSlotUI()
    {
        if (inventory.selectedItem.IsNull())
        {
            if (selectedItemSlot == null)
            {
                return;
            }
            else
            {
                Object.Destroy(selectedItemSlot);
            }
        }
        else
        {
            if (selectedItemSlot == null)
            {
                selectedItemSlot = Instantiate(selectedSlotUI, transform).GetComponent<SelectedItemSlot>();
                selectedItemSlot.UpdateItem(inventory.selectedItem);
            }
            else
            {
                selectedItemSlot.UpdateItem(inventory.selectedItem);
            }
        }
    }
}
