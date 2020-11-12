using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Tab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Text tabNameText;
    [SerializeField] private string tabName;
    [SerializeField] private GameObject page;
    public GameObject Page { get { return page; } set { page = value; } }

    [SerializeField] private TabSystem tabGroup;

    [HideInInspector]public Image backGround;

    [HideInInspector]public bool isSelected { get;private set; }

    private void Awake()
    {
        backGround = GetComponent<Image>();
        //tabNameText.text = tabName;
        tabGroup?.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup?.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup?.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup?.OnTabExit(this);
    }
}
