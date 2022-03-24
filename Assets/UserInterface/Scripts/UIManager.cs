using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Dictionary<string, UIComponent> menus;
    private UIComponent currentMenu;
    private readonly string mainMenuKey = "MainMenu";

    private void Awake()
    {
        menus = new Dictionary<string, UIComponent>();
        foreach (UIComponent menu in GetComponentsInChildren<UIComponent>(true))
        {
            menus.Add(menu.GetName(), menu);
            menu.ActiveMenu(true);
        }
        currentMenu = menus[mainMenuKey];
        currentMenu.ActiveMenu(true);
    }

    private void Start()
    {
        menus["Missions"].ActiveMenu(false);
        menus["Map"].ActiveMenu(false);
        menus["Inventory"].ActiveMenu(false);
    }



    public void SetCurrentMenu(string key)
    {
        if (key.Equals(currentMenu.GetName()))
        {
            CloseCurrentMenu();
        }
        else
        {
            CloseCurrentMenu();
            OpenMenu(key);
        }
    }

    private void OpenMenu(string key)
    {
        if (menus[key].IsFullScreen())
        {
            menus[mainMenuKey].ActiveMenu(false);
        }
        menus[key].ActiveMenu(true);
        currentMenu = menus[key];
    }

    public void CloseCurrentMenu()
    {
        currentMenu.ActiveMenu(false);
        currentMenu = menus[mainMenuKey];
        currentMenu.ActiveMenu(true);
    }


    private void OnOpenMap()
    {
        SetCurrentMenu("Map");
    }

    private void OnOpenInventory()
    {
        SetCurrentMenu("Inventory");
    }
}
