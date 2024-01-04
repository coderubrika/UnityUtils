using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Suburb.Utils
{
    public static class GeneralUtils
    {
        public static IObservable<T> StartWithDefault<T> (T defaultValue = default)
        {
            return Observable.Start(() => defaultValue);
        }

        public static string GetUID()
        {
            return DateTimeOffset.Now
                .ToUnixTimeMilliseconds()
                .ToString();
        }
    }
}
