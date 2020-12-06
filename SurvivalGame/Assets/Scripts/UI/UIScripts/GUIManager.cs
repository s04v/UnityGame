using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField] private Canvas GUICanvas;
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private GameObject HUD;
    [SerializeField] private UIMenu uiMenu;
    [SerializeField] private GameObject deathScreen;

    [SerializeField] private Player player;
    public Player Player { get { return player; } }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        GUIInput();
    }

    public void GUIInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            OpenMenu(MenuTabsTypes.Inventory);
        }
        if (Input.GetButtonDown("Map"))
        {
            OpenMenu(MenuTabsTypes.Map);
        }
        if (Input.GetButtonDown("SkillTree"))
        {
            OpenMenu(MenuTabsTypes.SkillTree);
        }
        if (Input.GetButtonDown("Crafting"))
        {
            OpenMenu(MenuTabsTypes.Crafting);
        }
        if (Input.GetButtonDown("LocalMenu"))
        {
            OpenMenu(MenuTabsTypes.LocalMenu);
        }
    }

    public void OpenMenu(MenuTabsTypes tabType)
    {
        MenuTabsGroup menuTabs = uiMenu.MenuTabsGroup;
        if (menuTabs.SelectedTab == null || (menuTabs.SelectedTab as MenuTab).TabType != tabType || !MenuCanvas.gameObject.activeSelf)
        {
            SetMenuScreenActive(true);
            menuTabs.OpenMenu(tabType);
        }
        else
        { 
            SetMenuScreenActive(false);
        }  
    }

    public void CloseMenu()
    {
        SetMenuScreenActive(false);
    }

    public void SetHUDActive(bool flag)
    {
        if (HUD != null)
            HUD.SetActive(flag);
    }

    public void SetMenuScreenActive(bool flag)
    {
        if (MenuCanvas != null)
        {
            MenuCanvas.gameObject.SetActive(flag);
        }
    }

}
