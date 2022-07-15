using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHUD : MonoBehaviour
{
    [SerializeField] Image _statusBar;
    [SerializeField] Color _goodStatusColor;
    [SerializeField] Color _attentionStatusColor;
    [SerializeField] Color _badStatusColor;

    const float GoodStatusPercent = 0.6f;
    const float AttentionStatusPercent = 0.3f;
    const float BadStatusPercent = 0.3f;

    public void SetValue(float value)
    {
        _statusBar.fillAmount = Mathf.Clamp01(value);
        _statusBar.color = GetStatusColor(_statusBar.fillAmount);
    }

    private Color GetStatusColor(float statusValue)
    {
        if(statusValue > GoodStatusPercent)
            return _goodStatusColor;
        else if(statusValue > AttentionStatusPercent)
            return _attentionStatusColor;
        return _badStatusColor;
    }
}