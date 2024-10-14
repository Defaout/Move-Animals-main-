using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PreAdScreen : MonoBehaviour
{
    public event Action StartPlayAd;
    public event Action StopPlayAd;

    [SerializeField] private ActiveLanguageSwitcher timer;
    [SerializeField] private int adDelaySec;
    [SerializeField] private PreAdClicker clicker;

    public static PreAdScreen Instance;

    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        if(!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Самый главный кусок который тебе нужен, вызывай вместо интеров,
    // он сам проверяет от Eiko, меняй на агаву если надо,
    // не забудь таймер на 90 секунд между рекламами
    public void ShowAdClicker()
    {
        if (YandexManager.Instance.CanShowAd())
        {
            StartCoroutine(AdTimer());
        }
    }

    public void ShowRewarded(Action action)
    {
        StartCoroutine(RewardedAdTimer(action));
    }

    private IEnumerator AdTimer()
    {
        AnimatedShow();
        //DrawHandler.SetShowingPreAd(true);
        clicker.StartField();

        for (int i = adDelaySec; i > 0; i--)
        {
            timer.UpdateValue(i);
            yield return new WaitForSeconds(1);
        }
        
        AnimatedHide();
        //DrawHandler.SetShowingPreAd(false);
        clicker.StopField();

        YandexManager.Instance.ShowInter();
    }

    private IEnumerator RewardedAdTimer(Action callback)
    {
        AnimatedShow();
        //DrawHandler.SetShowingPreAd(true);
        clicker.StartField();

        for (int i = adDelaySec; i > 0; i--)
        {
            timer.UpdateValue(i);
            yield return new WaitForSeconds(1);
        }

        AnimatedHide();
        //DrawHandler.SetShowingPreAd(false);
        clicker.StopField();

        callback.Invoke();
    }

    private void AnimatedShow()
    {
        canvasGroup.DOFade(1, 0.25f)
            .OnComplete(() =>
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                StartPlayAd?.Invoke();
            });
    }

    private void AnimatedHide()
    {
        canvasGroup
            .DOFade(0, 0.25f)
            .OnComplete(() =>
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                StopPlayAd?.Invoke();
            });
    }
}
