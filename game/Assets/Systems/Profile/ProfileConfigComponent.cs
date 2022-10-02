using SystemBase.Core;
using UniRx;

namespace Systems.Profile
{
    public class ProfileConfigComponent : GameComponent
    {
        public ReactiveProperty<DisplayProfile> activeProfile = new();
        public bool debugSwitchProfiles;
    }
}