using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector2 GetWorldMousePosition()
    {
        return MainCamera.Instance.MainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
