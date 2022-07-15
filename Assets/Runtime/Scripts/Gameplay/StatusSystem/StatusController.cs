using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    [Header("HUDs")]
    [SerializeField] StatusHUD _foodHUD;
    [SerializeField] StatusHUD _energyHUD;
    [SerializeField] StatusHUD _healthyHUD;

    [Header("Parameters")]
    [SerializeField] GameMode _gameMode;
    [SerializeField, Min(0)] float _foodDecreasePerSec;
    [SerializeField, Min(0)] float _energyDecreasePerSec;
    [SerializeField, Min(0)] float _healthyDecreasePerSec;
    [SerializeField, Min(0)] float _energyIncreasePerSec;
    [SerializeField, Min(0)] float _healthyIncreasePerSec;

    private const float MaxStatusValue = 1;

    float _foodStatusValue;
    float _energyStatusValue;
    float _healthyStatusValue;

    bool _shouldIncreaseEnergy;
    bool _shouldIncreaseHealthy;

    public void EnableEnergyIncrease(bool value) => _shouldIncreaseEnergy = value;
    public void EnableHealthyIncrease(bool value) => _shouldIncreaseHealthy = value;

    public void AddToFoodStatus(float value)
    {
        _foodStatusValue = Mathf.Clamp01(_foodStatusValue + value);
    }

    public void AddToEnergyStatus(float value)
    {
        _energyStatusValue = Mathf.Clamp01(_energyStatusValue + value);
    }

    public void AddToHealthyStatus(float value)
    {
        _healthyStatusValue = Mathf.Clamp01(_healthyStatusValue + value);
    }

    void Start() 
    {
        _foodStatusValue = MaxStatusValue;
        _energyStatusValue = MaxStatusValue;
        _healthyStatusValue = MaxStatusValue;
    }

    void Update()
    {
        var delta = _gameMode.TimeSpeed * Time.deltaTime;

        _foodStatusValue -= _foodDecreasePerSec * delta;

        if(_shouldIncreaseEnergy)
            _energyStatusValue += _energyIncreasePerSec * delta;
        else
            _energyStatusValue -= _energyDecreasePerSec * delta;

        if(_shouldIncreaseHealthy)
            _healthyStatusValue += _healthyIncreasePerSec * delta;
        else
            _healthyStatusValue -= _healthyDecreasePerSec * delta;

        _foodStatusValue = Mathf.Clamp01(_foodStatusValue);
        _energyStatusValue = Mathf.Clamp01(_energyStatusValue);
        _healthyStatusValue = Mathf.Clamp01(_healthyStatusValue);
    }

    void LateUpdate() 
    {
        _foodHUD.SetValue(_foodStatusValue);
        _energyHUD.SetValue(_energyStatusValue);
        _healthyHUD.SetValue(_healthyStatusValue);
    }
}