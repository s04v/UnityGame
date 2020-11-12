using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField] private Canvas GUICanvas;
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Player player;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    public void SetHUDActive(bool flag)
    {
        if (HUD != null)
            HUD.SetActive(flag);
    }

    public void SetMenuScreenActive(bool flag)
    {
        if (menuScreen != null)
        {
            menuScreen.SetActive(flag);
        }
    }

    /*public void SetMenuScreenActive()
    {
        HUD.
    }*/
}
