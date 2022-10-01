using System;
using SystemBase.Core;
using TMPro;
using UnityEngine.UI;

namespace Assets.Systems.Profile
{
    public class ProfileConfigComponent : GameComponent
    {
        public Image imageElement;
        public TextMeshProUGUI nameTextElement;
        public TextMeshProUGUI ageTextElement;
        public TextMeshProUGUI distanceTextElement;
        public TextMeshProUGUI bioTextElement;

        /// <summary>
        /// This will generate randomized profiles additionally to the custom created Profiles (scriptable objects)
        /// </summary>
        public int randomProfiles = 6;
    }
}