using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManagerPrePreAlpha : MonoBehaviour
{
    public PlayerPrePreAlpha player;

    [Header("HUD")]
    public BaseBare healthBar;
    public HotBarUI hotBar;

    [Header("Inventory")]
    public InventoryPage inventory;
    public GameObject Menu;

    [Header("Other")]
    public Image blurPanel;

    private void Start()
    {
        //player.updateHealth += healthBar.UpdateValue;
        healthBar.maxValue = player.maxHealth;
    }

    private void OnEnable()
    {
        player.updateHealth += healthBar.UpdateValue;
    }

    private void OnDisable()
    {
        player.updateHealth -= healthBar.UpdateValue;
    }

    private void Update()
    {
        GuiInput();
    }

    public void GuiInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (Menu.activeSelf)
            {
                Debug.Log("Ups");
            }
            else
            {
                Debug.Log("Nie Ups");
                if (inventory.gameObject.activeSelf)
                {
                    CloseInventory();
                }
                else
                {
                    OpenInventory();
                }
            }
        }
        if (Input.GetButtonDown("Menu"))
        {
            if (Menu.activeSelf)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenInventory()
    {
        inventory.gameObject.SetActive(true);
        blurPanel.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        inventory.gameObject.SetActive(false);
        blurPanel.gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        if (inventory.gameObject.activeSelf)
        {
            CloseInventory();
            return;
        }

        Menu.SetActive(true);
        blurPanel.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
        blurPanel.gameObject.SetActive(false);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
