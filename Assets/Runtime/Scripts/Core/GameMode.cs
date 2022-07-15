using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [field: SerializeField, Min(0)] public float TimeSpeed { get; set; }
    [SerializeField] StatusController _statusController;
    [SerializeField] TamagoshiController _tamagoshi;

    public void GoSleep()
    {
        _tamagoshi.GoSleep();
        _statusController.EnableEnergyIncrease(true);
    }

    public void WakeUp()
    {
        _tamagoshi.WakeUp();
        _statusController.EnableEnergyIncrease(false);
    }

    public void OnTouch()
    {
        if(!_tamagoshi.IsSleeping())
            _tamagoshi.OnTouch();
    }

    public void OnStartBath()
    {
        _statusController.EnableHealthyIncrease(true);
    }

    public void OnEndBath()
    {
        _statusController.EnableHealthyIncrease(false);
    }

    public void OnRecieveFood(float hungerPower)
    {
        _statusController.AddToFoodStatus(hungerPower);
        _tamagoshi.OnRecieveFood();
    }
}
