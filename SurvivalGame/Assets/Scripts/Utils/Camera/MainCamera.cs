using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] private Camera mainCamera;
    public Camera MainCam { get { return mainCamera; } }

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }
}
