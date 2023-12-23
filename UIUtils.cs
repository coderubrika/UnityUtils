﻿using System;
using System.Collections.Generic;
using DG.Tweening;
using Suburb.Utils.Serialization;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Suburb.Utils
{
    public class UIUtils
    {
        public static IDisposable UpdateContent(RectTransform content)
        {
            IDisposable disposable = null;
            disposable = Observable.NextFrame()
                .Subscribe(_ =>
                {
                    disposable.Dispose();
                    LayoutRebuilder.ForceRebuildLayoutImmediate(content);
                });

            return disposable;
        }

        public static IDisposable UpdateContents(IEnumerable<RectTransform> contents)
        {
            IDisposable disposable = null;

            disposable = Observable.NextFrame()
                .Subscribe(_ =>
                {
                    disposable.Dispose();
                    foreach (var content in contents)
                        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
                });

            return disposable;
        }

        public static Color GetNewAlpha(Color source, float alpha)
        {
            return new Color(source.r, source.g, source.b, alpha);
        }

        public static Tween FadeCanvas(CanvasGroup canvasGroup, ValueAnimationData<float> config)
        {
            canvasGroup.alpha = config.Start;
            return canvasGroup.DOFade(config.End, config.AnimationSettings.Duration)
                .SetEase(config.AnimationSettings.Easing)
                .OnKill(() => canvasGroup.alpha = config.End);
        }
    }
}
