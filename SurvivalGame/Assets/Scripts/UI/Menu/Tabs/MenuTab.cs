using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTab : Tab
{
    [SerializeField] private MenuTabsTypes tabType;

    public MenuTabsTypes TabType { get { return tabType; } }

}
