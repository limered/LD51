using SystemBase.Core;
using UniRx;

namespace Assets.Systems.Profile
{
    [GameSystem(typeof(ProfileSystem))]
    public class ProfileDisplaySystem : GameSystem<ProfileComponent>
    {
        public override void Register(ProfileComponent displaySystem)
        {
            ProfileService.activeProfile.Subscribe(newProfile => UpdateProfile(displaySystem, newProfile)).AddTo(displaySystem);
        }

        private static void UpdateProfile(ProfileComponent profileDisplaySystem, Profile newProfile)
        {
            profileDisplaySystem.image.sprite = newProfile.avatar;
            profileDisplaySystem.name.text = newProfile.name;
        }
    }
}
