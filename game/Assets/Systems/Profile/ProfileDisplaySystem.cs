using SystemBase.Core;
using SystemBase.Utils;
using UniRx;

namespace Systems.Profile
{
    [GameSystem(typeof(ProfileSystem))]
    public class ProfileDisplaySystem : GameSystem<ProfileUIConfigComponent>
    {
        public override void Register(ProfileUIConfigComponent component)
        {
            var profileSystem = IoC.Game.System<ProfileSystem>();
            profileSystem.ActiveProfile.Subscribe(newProfile => UpdateProfile(component, newProfile))
                .AddTo(component);
        }

        private static void UpdateProfile(ProfileUIConfigComponent profileUIConfigDisplaySystem, DisplayProfile newProfile)
        {
            profileUIConfigDisplaySystem.imageElement.sprite = newProfile.Profile.avatar;
            profileUIConfigDisplaySystem.nameTextElement.text = newProfile.Profile.name;
            profileUIConfigDisplaySystem.ageTextElement.text = $"{newProfile.Profile.age} years";
            profileUIConfigDisplaySystem.distanceTextElement.text = $"{newProfile.Profile.distance:F1} miles away";
            profileUIConfigDisplaySystem.bioTextElement.text = newProfile.Profile.text;
        }
    }
}