using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenController : MonoBehaviour
{
    [SerializeField] Screen _initialScreen;
    [SerializeField] Screen[] _screens;
    Screen _currentScreen;

    public void ShowKitchen()
    {
        ShowScreenWithType(typeof(KitchenScreen));
    }

    public void ShowBedroom()
    {
        ShowScreenWithType(typeof(BedroomScreen));
    }

    public void ShowBathroom()
    {
        ShowScreenWithType(typeof(BathroomScreen));
    }

    public void ShowScreenWithType(Screen.ScreenType screenType)
    {
        switch(screenType)
        {
            case Screen.ScreenType.Kitchen:
                ShowKitchen();
                break;
            case Screen.ScreenType.Bedroom:
                ShowBedroom();
                break;
            case Screen.ScreenType.Bathroom:
                ShowBathroom();
                break;
            default:
                Debug.LogWarning("Tipo não encontrado");
                break;
        }
    }

    private void Start() 
    {
        foreach(var screen in _screens)
            screen?.CloseScreen();

        if(_initialScreen != null)
            ShowScreenWithType(_initialScreen.GetType()); 
    }

    private void ShowScreenWithType(Type t)
    {
        Screen screenToOpen = GetScreenWithType(t);

        if(screenToOpen != null)
        {
            CloseCurrentScreen();
            _currentScreen = screenToOpen;
            _currentScreen?.ShowScreen();
        }
    }

    private Screen GetScreenWithType(Type t)
    {
        if(t == null)
            return null;

        foreach(Screen screen in _screens)
        {
            if(screen.GetType() == t)
                return screen;
        }
        return null;
    }

    private void CloseCurrentScreen()
    {
        _currentScreen?.CloseScreen();
    }
}