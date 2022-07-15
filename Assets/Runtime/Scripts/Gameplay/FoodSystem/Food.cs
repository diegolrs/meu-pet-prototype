using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] Canvas _canvas;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField, Range(0, 1)] float _hungerPower;
    [SerializeField] GameMode _gameMode;
    [SerializeField] BoxCollider2D _area;

    Vector2 _initialPos;

    public float GetHungerPower() => _hungerPower;

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _initialPos = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        //Debug.Log("OnBeginDrag");
        _canvasGroup.alpha = .80f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        //Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.anchoredPosition = _initialPos;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        //Debug.Log("OnPointerDown");
    }
}
