using SystemBase.Core;
using UnityEngine;

namespace Systems.Profile
{
    public class ProfileConfigComponent : GameComponent
    {
        /// <summary>
        /// This will generate randomized profiles additionally to the custom created Profiles (scriptable objects)
        /// </summary>
        public int randomProfiles = 6;

        public Sprite[] profileSprites;
    }
}