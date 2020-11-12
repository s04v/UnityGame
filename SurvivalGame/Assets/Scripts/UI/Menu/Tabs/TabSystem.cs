using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{

    [SerializeField] private List<Tab> tabsList;

    [SerializeField] private Sprite activeTab;
    [SerializeField] private Sprite hoverTab;
    [SerializeField] private Sprite idleTab;

    [SerializeField] private Tab selectedTab;
    [SerializeField] private Tab defaultTab;

    /*private void OnEnable()
    {
        if (tabsList.Fin(defaultTab))
        {
            OnTabSelected(defaultTab);
        }
        else
        { 
            OnTabSelected(tabsList[0]);
        }
    }*/

    public void Subscribe(Tab tab)
    {
        if (tabsList == null)
            tabsList = new List<Tab>();
        tabsList.Add(tab);
        tab.backGround.sprite = idleTab;
    }

    public void OnTabEnter(Tab tab)
    {
        ResetTabs();
        if(selectedTab == null || tab != selectedTab)
            tab.backGround.sprite = hoverTab;
    }

    public void OnTabExit(Tab tab)
    {
        ResetTabs();
    }

    public void OnTabSelected(Tab tab)
    {
        selectedTab = tab;
        ResetTabs();
        tab.backGround.sprite = activeTab;
        foreach (Tab tabs in tabsList)
        {
            if (tabs == selectedTab)
            {
                tabs.Page.SetActive(true);
            }
            else
            {
                tabs.Page.SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (Tab tab in tabsList)
        {
            if (selectedTab != null && tab == selectedTab)
                continue;
            tab.backGround.sprite = idleTab;
        }
    }
}
