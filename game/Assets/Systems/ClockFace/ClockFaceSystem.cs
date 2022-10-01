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
            
        }

        public override void Register(TimeComponent component)
        {
            _timer.Value = component;
        }
    }

    public class ClockFaceComponent : GameComponent
    {
        public GameObject MainHand;
        public GameObject SecondHand;
    }
}