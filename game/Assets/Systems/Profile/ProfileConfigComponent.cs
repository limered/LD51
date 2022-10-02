using SystemBase.Core;
using UniRx;

namespace Systems.Profile
{
    public class ProfileConfigComponent : GameComponent
    {
        public ReactiveProperty<DisplayProfile> activeProfile = new();
        /// This will generate randomized profiles additionally to the custom created Profiles (scriptable objects)
        /// </summary>
        public int randomProfiles = 6;

        public Sprite[] profileSprites;
    }
}