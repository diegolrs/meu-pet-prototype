using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeScreenBar : MonoBehaviour
{
    [SerializeField] Screen _currentScreen;
    [SerializeField] Screen.ScreenType _screenOnLeft;
    [SerializeField] Screen.ScreenType _screenOnRight;
    [SerializeField] TMP_Text _text;

    public void ShowLeftScreen() => ShowScreen(_screenOnLeft);
    public void ShowRightScreen() => ShowScreen(_screenOnRight);

    private void ShowScreen(Screen.ScreenType screenType)
    {
        var controller = FindObjectOfType<ScreenController>();
        controller?.ShowScreenWithType(screenType);
    }

    private void Start() 
    {
        _text.text = _currentScreen.ToString();
    }
}
