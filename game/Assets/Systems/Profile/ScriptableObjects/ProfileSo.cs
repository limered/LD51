using UnityEngine;

namespace Systems.Profile.ScriptableObjects
{
    [CreateAssetMenu(menuName = "LD51/Profile", fileName = "Profile", order = 0)]
    public class ProfileSo : ScriptableObject
    {
        public ProfileImage profileImage;
        public new string name;
        [TextArea(30, 60)]
        public string text;
        public int age;
        public float distance;
        public PersonalityTrait[] traits;
    }
}
