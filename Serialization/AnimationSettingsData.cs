using System;
using DG.Tweening;
using Newtonsoft.Json;
using UnityEngine.Serialization;

namespace Suburb.Utils.Serialization
{
    [Serializable]
    public class AnimationSettingsData
    {
        [JsonProperty("duration")]
        public float Duration;

        [JsonProperty("easing")]
        public Ease Easing;
    }
}