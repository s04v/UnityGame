using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseButton : Button
{
    [SerializeField] private Sprite hoverButton;
    [SerializeField] private Sprite idleButton;

    private Image buttonIcon;

    private void Start()
    {
        buttonIcon = GetComponent<Image>();
    }

    public override void OnLeftClick()
    {
        ResetButtonIcon();
        GUIManager.Instance.CloseMenu();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        buttonIcon.sprite = hoverButton;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        ResetButtonIcon();
    }

    public void ResetButtonIcon()
    {
        buttonIcon.sprite = idleButton;
    }
}
