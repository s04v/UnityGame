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
        /*Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//(Vector2)Input.mousePosition + offset;// ;//
        //mousePos -= new Vector2(Screen.height, Screen.width) / 2;
        rect.anchoredPosition = mousePos + offset;//Input.mousePosition; //*/
        Vector2 _newPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, Input.mousePosition, TargetCanvas.worldCamera, out _newPosition);
        _newPosition += offset;
        transform.position = TargetCanvas.transform.TransformPoint(_newPosition);
    }

}
