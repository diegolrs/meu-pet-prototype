using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScreen : Screen
{
    [SerializeField] GameObject _food;

    public override void ShowScreen()
    {
        _food.gameObject.SetActive(true);
        base.ShowScreen();
    }

    public override void CloseScreen()
    {
        _food.gameObject.SetActive(false);
        base.CloseScreen();
    }

    public override string ToString()
    {
        return "Cozinha";
    }

    private void Awake()
    {
        _food.gameObject.SetActive(false);
    }
}