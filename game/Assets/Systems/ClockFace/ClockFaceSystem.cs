using SystemBase.Core;
using SystemBase.Utils;
using Systems.Time;
using UniRx;
using Unity.Mathematics;
using UnityEngine;

namespace Systems.ClockFace
{
    [GameSystem]
    public class ClockFaceSystem : GameSystem<ClockFaceComponent, TimeComponent>
    {
        private readonly ReactiveProperty<TimeComponent> _timer = new(null);
        
        public override void Register(ClockFaceComponent clock)
        {
            _timer.WhereNotNull().Subscribe(_ => StartTicking(clock)).AddTo(clock);
        }

        private void StartTicking(ClockFaceComponent clock)
        {
            SystemUpdate(clock).Subscribe(AnimateHands).AddTo(clock);
        }

        private void AnimateHands(ClockFaceComponent clock)
        {
            var progress = _timer.Value.progress.Value * 10;
            var start = math.floor(progress);
            var t = math.frac(progress);
            var posInRange = math.smoothstep(0, 1, t);
            clock.SecondHand.transform.rotation = Quaternion.Euler(0, 0, (posInRange + start) * -36);
            
            clock.MainHand.transform.rotation = Quaternion.Euler(0, 0, (UnityEngine.Time.realtimeSinceStartup / -6) % 360);
        }

        public override void Register(TimeComponent component)
        {
            _timer.Value = component;
        }
    }
}