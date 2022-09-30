using SystemBase.Core;
using Systems.Time.Events;
using UniRx;

namespace Systems.Time
{
    [GameSystem]
    public class TimeSystem : GameSystem<TimeComponent>
    {
        public override void Register(TimeComponent component)
        {
            component.startTime = UnityEngine.Time.realtimeSinceStartup;
            SystemFixedUpdate(component).Subscribe(Tick).AddTo(component);
        }

        private static void Tick(TimeComponent timer)
        {
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