using System;
using SystemBase.Core;
using UniRx;

namespace Systems.Time
{
    public class TimeComponent : GameComponent
    {
        public float tickDurationInSeconds;
        
        public float startTime;
        public FloatReactiveProperty progress = new(1);
        
        [NonSerialized] public readonly ReactiveCommand tick = new();
    }
}