using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool interactable;
    public bool isLeftPressed { get; private set; }
    public bool isRightPressed { get; private set; }
    public bool isMiddlePressed { get; private set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isLeftPressed = false;
            OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightPressed = false;
            OnRightClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            isMiddlePressed = false;
            OnMiddleClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isLeftPressed = false;
            OnLeftUp();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightPressed = false;
            OnRightUp();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            isMiddlePressed = false;
            OnMiddleUp();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isLeftPressed = true;
            OnLeftDown();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            isRightPressed = true;
            OnRightDown();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            isMiddlePressed = true;
            OnMiddleDown();
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public virtual void OnLeftUp()
    {
        //Debug.Log("Left up");
    }

    public virtual void OnRightUp()
    {
     //   Debug.Log("Right up");
    }

    public virtual void OnMiddleUp()
    {
        //Debug.Log("Middle up");
    }

    public virtual void OnLeftDown()
    {
       // Debug.Log("Left down");
    }

    public virtual void OnRightDown()
    {
       // Debug.Log("Right down");
    }

    public virtual void OnMiddleDown()
    {
        //Debug.Log("Middle down");
    }

    public virtual void OnLeftClick()
    {
       // Debug.Log("Left click");
    }

    public virtual void OnRightClick()
    {
        //Debug.Log("Right click");
    }

    public virtual void OnMiddleClick()
    {
        //Debug.Log("Middle click");
    }

}
