using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemSlot : SlotUI
{
    private RectTransform rect;
    [SerializeField] private Vector2 offset;

    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = (Vector2)Input.mousePosition + offset;//Camera.main.ScreenToWorldPoint(Input.mousePosition); ;//
        rect.anchoredPosition = mousePos;//Input.mousePosition; //+ offset;
    }

}
