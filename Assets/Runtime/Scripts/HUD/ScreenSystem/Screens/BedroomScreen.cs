using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedroomScreen : Screen
{
    [SerializeField] Image _darkFilter;
    [SerializeField] GameMode _gameMode;

    bool _darkFilterIsOn;

    private void Awake() 
    {
        _darkFilter.gameObject.SetActive(false);    
    }

    public void TriggerLight()
    {
        _darkFilterIsOn = !_darkFilterIsOn;

        if(_darkFilterIsOn)
            TurnOffLights();
        else
            TurnOnLights();
    }

    public void TurnOnLights()
    {
        _darkFilterIsOn = false;
        _darkFilter.gameObject.SetActive(false);
        _gameMode.WakeUp();
    }

    public void TurnOffLights()
    {
        _darkFilterIsOn = true;
        _darkFilter.gameObject.SetActive(true);
        _gameMode.GoSleep();
    }

    public override void CloseScreen()
    {
        if(_darkFilterIsOn)
            TurnOnLights();

        base.CloseScreen();
    }

    public override string ToString()
    {
        return "Quarto";
    }

    private void OnEnable() 
    {
        if(_darkFilterIsOn)
            TurnOnLights();    
    }
}
