using System;
using SystemBase.Core;

namespace Assets.Systems.Profile
{
    [GameSystem]
    public class ProfileSystem : GameSystem<ProfileComponent>
    {
        public override void Register(ProfileComponent displaySystem)
        {
            ProfileService.Init();
            ProfileService.ToNextProfile();
        }
    }
}
