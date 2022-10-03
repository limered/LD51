using System.Collections;
using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.Utils;
using Systems.Player.Events;
using Systems.Profile;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems.Player
{
    public class ShowHeartbreakNotificationEvt
    {
        public DisplayProfile profile;

    }

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
                MessageBroker.Default.Publish(new GameMsgEnd());
            }
            
            MessageBroker.Default.Publish(new ShowHeartbreakNotificationEvt{profile = msg.profile});
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

            MessageBroker.Default.Receive<ShowHeartbreakNotificationEvt>()
                .Subscribe(msg => ShowNotification(msg, ui))
                .AddTo(ui);

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

        private void ShowNotification(ShowHeartbreakNotificationEvt msg, LifeUiComponent ui)
        {
            ui.messageText.text = msg.profile.Profile.name.Split(' ')[0] + " broke your heart.";
            
            Observable.FromCoroutine(_ => ShowMessage(ui.messageContainer.GetComponent<RectTransform>(), 0, 24))
                .Subscribe();
        }

        private IEnumerator ShowMessage(RectTransform message, float startPos, float endPos)
        {
            var animationSteps = 60;
            var animationTranslate = (endPos - startPos) / animationSteps;
            for (var i = 0; i < animationSteps; i++)
            {
                message.anchoredPosition = new Vector2(
                    message.anchoredPosition.x, 
                    message.anchoredPosition.y - animationTranslate);

                yield return null;
            }

            yield return new WaitForSecondsRealtime(2f);
            
            for (var i = 0; i < animationSteps; i++)
            {
                message.anchoredPosition = new Vector2(
                    message.anchoredPosition.x, 
                    message.anchoredPosition.y + animationTranslate);
                
                yield return null;
            }
        }
    }
}