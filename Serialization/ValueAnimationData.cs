using System;
using UnityEngine;

namespace Suburb.Utils.Serialization
{
    [Serializable]
    public class ValueAnimationData<TValue>
    {
        [SerializeField] private AnimationSettingsData animationSettings;
        [SerializeField] private TValue start;
        [SerializeField] private TValue end;

        public AnimationSettingsData AnimationSettings => animationSettings;
        public TValue Start => start;
        public TValue End => end;
        
    }
}