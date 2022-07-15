using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public enum ScreenType
    {
        Kitchen,
        Bedroom,
        Bathroom
    }

    public override string ToString()
    {
        return GetType().ToString();
    }

    public virtual void ShowScreen()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}