using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : Singleton<CursorController>
{
    public Texture2D normalCursor;
    public Texture2D actionCursor;
    public Texture2D dialogueCursor;
    public Texture2D axeCursor;
    public Texture2D pickaxeCursor;
    public Texture2D aimCursor;
    public Texture2D meleeCursor;
    
    public enum cursorModes
    {
        Normal,
        Action,
        Axe,
        Pickaxe,
        Aim,
        Melee
    }

    private cursorModes i = 0;

    [Space]
    [SerializeField] private GameObject selectedSlotPrefab;
    [SerializeField] private SelectedItemSlot selectedItemSlot;



    void Start()
    {
        SwitchCursor(cursorModes.Aim);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchCursor(cursorModes cursorMode)
    {
        Texture2D cursor;
        Vector2 offset = Vector2.zero;
        switch (cursorMode)
        {
            case cursorModes.Normal:
                cursor = normalCursor;
                break;
            case cursorModes.Action:
                cursor = normalCursor;
                break;
            case cursorModes.Axe:
                cursor = normalCursor;
                break;
            case cursorModes.Pickaxe:
                cursor = normalCursor;
                break;
            case cursorModes.Aim:
                cursor = aimCursor;
                offset = new Vector2(32, 32);
                break;
            case cursorModes.Melee:
                cursor = normalCursor;
                break;
            default:
                cursor = normalCursor;
                break;
        }
        Cursor.SetCursor(cursor, offset, CursorMode.ForceSoftware);
    }
}
