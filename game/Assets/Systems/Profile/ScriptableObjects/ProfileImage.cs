using UnityEngine;

namespace Systems.Profile.ScriptableObjects
{
    [CreateAssetMenu(menuName = "LD51/ProfileImage", fileName = "ProfileImage")]
    public class ProfileImage : ScriptableObject
    {
        public Sprite avatar;
        public PersonalityTrait[] traits;
        public bool shouldNotBeRandom;
    }
}