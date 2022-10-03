using SystemBase;
using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.Utils;
using Systems.Player.Events;
using UniRx;
using Object = UnityEngine.Object;

namespace Systems.Player
{
    [GameSystem]
    public class LifeSystem : GameSystem<LifeComponent, LifeUiComponent>
    {
        public override void Register(LifeComponent component)
        {
            MessageBroker.Default.Receive<GameMsgStart>()
                .Subscribe(_ => { component.livesLeft.Value = component.initialLives; })
                .AddTo(component);

            MessageBroker.Default.Receive<LoseLifeMessage>()
                .Subscribe(msg => LoseALife(msg, component))
                .AddTo(component);
        }

        private void LoseALife(LoseLifeMessage msg, LifeComponent component)
        {
            component.livesLeft.Value -= 1;
            if (component.livesLeft.Value <= 0)
            {
                MessageBroker.Default.Publish(new LoseMessage());
            }
        }

        public override void Register(LifeUiComponent component)
        {
            MessageBroker.Default.Receive<GameMsgStart>()
                .Subscribe(_ => { component.lifeComponent.Value = Object.FindObjectOfType<LifeComponent>(); })
                .AddTo(component);

            component.lifeComponent.WhereNotNull()
                .Subscribe(lifeComponent => SetupNewGame(lifeComponent, component))
                .AddTo(component);
        }

        private void SetupNewGame(LifeComponent lifeComponent, LifeUiComponent ui)
        {
            var hearts = ui.heartsContainer.GetComponentsInChildren<HeartComponent>();
            foreach (var heartComponent in hearts)
            {
                heartComponent.Heal();
            }

            lifeComponent.livesLeft.Subscribe(healedHeartsLeft =>
            {
                foreach (var heartComponent in hearts)
                {
                    heartComponent.Break();
                }
                for (var i = 0; i < healedHeartsLeft; i++)
                {
                    hearts[i].Heal();
                }
            }).AddTo(ui);
        }
    }
}