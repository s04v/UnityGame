using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private MenuTabsGroup menuTabsGroup;
    public MenuTabsGroup MenuTabsGroup { get { return menuTabsGroup; } }

    [SerializeField] private CloseButton closeButton;

    [SerializeField] private bool isOpened;
    public bool IsOpened { get { return isOpened; } }

    private void OnEnable()
    {
        isOpened = true;
    }

    private void OnDisable()
    {
        isOpened = false;
    }

    public void OpenMenu()
    { }

    public void CloseMenu()
    { }

}
