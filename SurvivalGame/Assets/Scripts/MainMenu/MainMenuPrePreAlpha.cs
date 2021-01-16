using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPrePreAlpha : MonoBehaviour
{
    [Header("Main menu:")]
    public Canvas MenuCanvas;
    public GameObject ExitMenu;

    [Header("Main menu buttons:")]
    public MenuButton Start;
    public MenuButton Exit;

    public void StartTheGame()
    {
        //Application.LoadLevel("SampleScene");
        SceneManager.LoadScene(1);
    }

    public void OpenExitPannel()
    {
        ExitMenu.SetActive(true);
    }

    public void CloseExitPannel()
    {
        ExitMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
