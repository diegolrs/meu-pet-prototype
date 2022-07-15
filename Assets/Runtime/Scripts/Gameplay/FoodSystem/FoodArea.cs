using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodArea : MonoBehaviour
{
    [SerializeField] GameMode _gameMode;
    Food _food;
    bool _isFeeding;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Food>() is Food food) 
        {
            _food = food;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Food>() is Food food) 
        {
            _food = null;
        }
    }

    private void Update() 
    {
        if(_food != null)
        {
            _gameMode.OnRecieveFood(_food.GetHungerPower() * Time.deltaTime);
        }
    }
}