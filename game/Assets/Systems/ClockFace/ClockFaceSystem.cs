using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.GameState.States;
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
            _timer.WhereNotNull()
                .Subscribe(_ => StartTicking(clock))
                .AddTo(clock);
        }

        private void StartTicking(ClockFaceComponent clock)
        {
            MessageBroker.Default.Receive<GameMsgStart>()
                .Subscribe(_ => { clock.hourHandStart = UnityEngine.Time.realtimeSinceStartup; })
                .AddTo(clock);

            SystemUpdate(clock).Subscribe(AnimateHands).AddTo(clock);
        }

        private void AnimateHands(ClockFaceComponent clock)
        {
            if (IoC.Game.gameStateContext.CurrentState.Value.GetType() != typeof(Running)) return;

            var progress = _timer.Value.progress.Value * 10;
            var start = math.floor(progress);
            var t = math.frac(progress);
            var posInRange = math.smoothstep(0, 1, t);
            clock.SecondHand.transform.rotation = Quaternion.Euler(0, 0, (posInRange + start) * -36);

            var hourHandDegrees = (UnityEngine.Time.realtimeSinceStartup - clock.hourHandStart) / -6 % 360;
            clock.MainHand.transform.rotation = Quaternion.Euler(0, 0, hourHandDegrees);
        }

        public override void Register(TimeComponent component)
        {
            _timer.Value = component;
        }
    }
}