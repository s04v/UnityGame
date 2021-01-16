using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [Header("Main menu:")]
    public Canvas MenuCanvas;
    public GameObject ExitPanel;

    [Header("Main menu buttons:")]
    public MenuButton NewGame;
    public MenuButton LoadGame;
    public MenuButton Options;
    public MenuButton Exit;

    [Header("Setting:")]
    public Canvas SettingCanvas;

    [Header("Setting buttons:")]
    public MenuButton Back;



    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenExitPannel()
    {
        
        ExitPanel.SetActive(true);
    }

    public void CloseExitPannel()
    {
        ExitPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        Debug.Log("Suka");
        MenuCanvas.gameObject.SetActive(false);
        SettingCanvas.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        MenuCanvas.gameObject.SetActive(true);
        SettingCanvas.gameObject.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
