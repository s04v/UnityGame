using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemSlot : SlotUI
{
    private RectTransform rect;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Canvas TargetCanvas;

    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
        TargetCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    { 
        Vector2 _newPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, Input.mousePosition, TargetCanvas.worldCamera, out _newPosition);
        _newPosition += offset;
        transform.position = TargetCanvas.transform.TransformPoint(_newPosition);
    }

}
