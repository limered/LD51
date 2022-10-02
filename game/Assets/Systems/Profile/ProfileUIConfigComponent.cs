using SystemBase.Core;
using TMPro;
using UnityEngine.UI;

namespace Systems.Profile
{
    public class ProfileUIConfigComponent : GameComponent
    {
        public Image imageElement;
        public TextMeshProUGUI nameTextElement;
        public TextMeshProUGUI ageTextElement;
        public TextMeshProUGUI distanceTextElement;
        public TextMeshProUGUI bioTextElement;
    }
}