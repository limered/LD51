using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.GameState.States;
using SystemBase.Utils;
using Systems.Time.Events;
using UniRx;

namespace Systems.Time
{
    [GameSystem]
    public class TimeSystem : GameSystem<TimeComponent>
    {
        public override void Register(TimeComponent component)
        {
            SystemFixedUpdate(component).Subscribe(Tick).AddTo(component);
            
            MessageBroker.Default.Receive<GameMsgStart>()
                .Subscribe(_ =>
                {
                    component.startTime = UnityEngine.Time.realtimeSinceStartup;
                })
                .AddTo(component);
        }

        private static void Tick(TimeComponent timer)
        {
            if (IoC.Game.gameStateContext.CurrentState.Value.GetType() != typeof(Running)) return;
            
            var endTime = timer.startTime + timer.tickDurationInSeconds;
            var time = UnityEngine.Time.realtimeSinceStartup;
            timer.progress.Value = (time - timer.startTime) / timer.tickDurationInSeconds;
            if (endTime <= time)
            {
                MessageBroker.Default.Publish(new TickEvent());
                timer.tick.ForceExecute();
                timer.startTime = time;
            }
        }
    }
}