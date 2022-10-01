using UnityEngine;

namespace Assets.Systems.Profile
{
    [CreateAssetMenu]
    public class Profile : ScriptableObject
    {
        public Sprite avatar;
        public new string name;
    }
}
