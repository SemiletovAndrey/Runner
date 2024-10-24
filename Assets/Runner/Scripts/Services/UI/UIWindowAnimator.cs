using DG.Tweening;
using System;
using UnityEngine;

public class UIWindowAnimator 
{
    private RectTransform windowRect;

    private float scaleDuration = 0.05f;

    public UIWindowAnimator(RectTransform pauseRect)
    {
        windowRect = pauseRect;
    }

    public void AnimateExpandWindow(Vector3 targetScale)
    {
        windowRect.localScale = Vector3.zero;
        windowRect.DOScale(targetScale, scaleDuration)
            .SetEase(Ease.OutBack);
    }
}
