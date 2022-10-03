using System.Linq;
using SystemBase.Core;
using Systems.Player.Events;
using UniRx;

namespace Systems.Menu
{
    [GameSystem]
    public class GameOverSystem : GameSystem<RestartGameComponent>
    {
        public override void Register(RestartGameComponent component)
        {
            MessageBroker.Default.Receive<WinMessage>()
                .Subscribe((msg) =>
                {
                    foreach (var profile in msg.profiles)
                    {
                        var result = GameComponent.Instantiate(component.loveResultPrefab, component.resultContainer.transform);
                        result.GetComponent<LoveResultComponent>().image.sprite = profile.Profile.profileImage.avatar;
                        result.GetComponent<LoveResultComponent>().text.text = profile.Profile.traits.Aggregate("", (p, n) => p + ", " + n.text );
                    }
                })
                .AddTo(component);
        }
    }
}