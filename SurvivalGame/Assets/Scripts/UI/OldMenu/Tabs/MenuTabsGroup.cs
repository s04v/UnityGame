using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuTabsTypes {Inventory, Crafting, SkillTree, Map, LocalMenu }

public class MenuTabsGroup : TabSystem
{
    public void OpenMenu(MenuTabsTypes tabType)
    {
        foreach (MenuTab tab in tabsList)
        {
            if (tab.TabType == tabType)
            {
                OnTabSelected(tab);
                return;
            }
        }
    }
}
