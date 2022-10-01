using SystemBase.Core;
using SystemBase.Utils;
using Systems.Time;
using UniRx;
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
            var progress = _timer.Value.progress.Value;

            var handTransform = clock.SecondHand.transform;
            // clock.SecondHand.transform.localRotation = Quaternion.identity;
            handTransform.rotation = Quaternion.Euler(0, 0, progress * -360);
        }

        public override void Register(TimeComponent component)
        {
            _timer.Value = component;
        }
    }
}