using Systems.Properties;
using UnityEngine;

namespace Assets.Systems.Profile
{
    [CreateAssetMenu]
    public class Profile : ScriptableObject
    {
        public Sprite avatar;
        public new string name;
        public string text;
        public int age;
        public float distance;
        public PersonalityTrait[] traits;
    }
}
