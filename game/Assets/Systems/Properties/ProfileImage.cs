using UnityEngine;

namespace Systems.Properties
{
    [CreateAssetMenu(menuName = "LD51/ProfileImage", fileName = "ProfileImage")]
    public class ProfileImage : ScriptableObject
    {
        public Sprite avatar;
        public PersonalityTrait[] traits;
    }
}