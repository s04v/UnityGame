using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedHotbarItemMarker : MonoBehaviour
{
    protected RectTransform _rectTransform;
    protected GameObject _currentSelection;
    protected Vector3 _originPosition;
    protected Vector3 _originLocalScale;
    protected Vector3 _originSizeDelta;
    protected float _originTime;
    protected bool _originIsNull = true;
    protected float _deltaTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
