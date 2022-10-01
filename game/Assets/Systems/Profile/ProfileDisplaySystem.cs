using SystemBase.Core;
using SystemBase.Utils;
using UniRx;

namespace Assets.Systems.Profile
{
    [GameSystem(typeof(ProfileSystem))]
    public class ProfileDisplaySystem : GameSystem<ProfileConfigComponent>
    {
        public override void Register(ProfileConfigComponent displaySystem)
        {
            var profileSystem = IoC.Game.System<ProfileSystem>();
            profileSystem.ActiveProfile.Subscribe(newProfile => UpdateProfile(displaySystem, newProfile))
                .AddTo(displaySystem);
        }

        private static void UpdateProfile(ProfileConfigComponent profileConfigDisplaySystem, DisplayProfile newProfile)
        {
            profileConfigDisplaySystem.imageElement.sprite = newProfile.Profile.avatar;
            profileConfigDisplaySystem.nameTextElement.text = newProfile.Profile.name;
            profileConfigDisplaySystem.ageTextElement.text = $"{newProfile.Profile.age} years";
            profileConfigDisplaySystem.distanceTextElement.text = $"{newProfile.Profile.distance:F1} miles away";
            profileConfigDisplaySystem.bioTextElement.text = newProfile.Profile.text;
        }
    }
}