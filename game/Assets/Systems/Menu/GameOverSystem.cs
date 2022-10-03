using System.Linq;
using SystemBase.Core;
using Systems.Player;
using Systems.Player.Events;
using UniRx;

namespace Systems.Menu
{
    [GameSystem]
    public class GameOverSystem : GameSystem<RestartGameComponent, WishlistComponent>
    {
        private WishlistComponent _wishlist;

        public override void Register(RestartGameComponent component)
        {
            MessageBroker.Default.Receive<WinMessage>()
                .Subscribe((msg) =>
                {
                    component.loseContainer.SetActive(false);
                    component.resultContainer.SetActive(true);

                    var soulmates = _wishlist.wantPositives
                        .Select(x => (profile: msg.profiles.First(p => p.Profile.traits.Any(t => t == x.trait)),
                            trait: x.trait))
                        .ToArray();

                    foreach (var mate in soulmates)
                    {
                        var result = GameComponent.Instantiate(component.loveResultPrefab,
                            component.resultContainer.transform);
                        result.GetComponent<LoveResultComponent>().image.sprite =
                            mate.profile.Profile.profileImage.avatar;
                        result.GetComponent<LoveResultComponent>().text.text = $"also likes <b>{mate.trait.text}</b>";
                    }
                })
                .AddTo(component);

            MessageBroker.Default.Receive<LoseMessage>()
                .Subscribe((msg) =>
                {
                    component.loseContainer.SetActive(true);
                    component.resultContainer.SetActive(false);
                })
                .AddTo(component);
        }

        public override void Register(WishlistComponent component)
        {
            _wishlist = component;
        }
    }
}