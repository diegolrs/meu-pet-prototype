using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagoshiController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    bool _isSleeping;

    public bool IsSleeping() => _isSleeping;

    public void GoSleep()
    {
        _isSleeping = true;
       _anim.Play(TamagoshiAnimationKeys.SleepAnimation);
    }

    public void WakeUp()
    {
        _isSleeping = false;
        _anim.Play(TamagoshiAnimationKeys.WakeUpAnimation);
    }

    public void OnTouch()
    {
        _anim.Play(TamagoshiAnimationKeys.TweenAnimation);
    }

    public void OnRecieveFood()
    {
        _anim.Play(TamagoshiAnimationKeys.TweenAnimation);
    }
}