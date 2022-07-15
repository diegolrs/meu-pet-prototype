using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomScreen : Screen
{
    [SerializeField] GameObject _bathtub;
    [SerializeField] GameMode _gameMode;

    public override string ToString()
    {
        return "Banheiro";
    }

    public override void ShowScreen()
    {
        StartBath();
        base.ShowScreen();
    }

    public override void CloseScreen()
    {
        EndBath();
        base.CloseScreen();
    }

    void StartBath()
    {
        _bathtub.SetActive(true);
        _gameMode.OnStartBath();
    }

    void EndBath()
    {
        _bathtub.SetActive(false);
        _gameMode.OnEndBath();
    }
}