using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuButton : Button
{
    [SerializeField] private Sprite hoverButton;
    [SerializeField] private Sprite idleButton;

    [Header("Events:")]
    [SerializeField] private MenuButtonEvent onClick;

    private Image buttonIcon;

    private void Start()
    {
        buttonIcon = GetComponent<Image>();
    }

    public override void OnLeftClick()
    {
        Debug.Log("Ok Ok Ok");
        onClick.Invoke();
    }
}

[System.Serializable]
public class MenuButtonEvent : UnityEvent { }
